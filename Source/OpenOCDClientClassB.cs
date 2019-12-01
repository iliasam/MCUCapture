using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using TentacleSoftware.Telnet;

namespace MCUCapture
{
    /// <summary>
    /// Comanication with OpenOCD
    /// </summary>
    class OpenOCDClientClassB
    {
        TelnetClient client;
        public bool IsConnected = false;
        BackgroundWorker BackWorker = new BackgroundWorker();
        CancellationTokenSource _cancellationSource;
        bool ReadyForSend = true;

        enum SetWatchpointsStateType
        {
            Idle,
            WaitForHalt,
            WaitForWPSet,
            WaitForEvent,
            WaitForCaptureDone,
        }

        SetWatchpointsStateType SetWatchpointsState = SetWatchpointsStateType.Idle;

        public int LinesReceived = 0;

        UInt32 CmdReadMemorySize = 0;//not good solution

        CmdReadMemoryClass CmdReadMemoryObj = new CmdReadMemoryClass();

        /// <summary>
        /// This callback if used to send data that was received after "MemoryRead" command
        /// </summary>
        public Action<byte[]> MemoryReadDataCallback;

        public bool MCUHalted = false;

        bool WatchpointEventDetected = false;
        bool AutoCleanWatchPoint = false;
        public bool WatchpointIsSet = false;

        // Need to capture data when watchpoint event happens
        bool WPCaptureData = false;

        // We need to set Value watchpoint
        bool AutoSetValueWatchpoint = false;

        // Address of last received Watchpoint
        //public UInt32 LastWPAddress = 0;

        // Address of Watchpoint which we want to set
        public UInt32 SetWPAddress = 0;

        // Address of data to be read when watchpoint will be detected
        public UInt32 WPDataAddress = 0;

        // Address of Value Watchpoint Variable
        public UInt32 WPValueTriggerAddress = 0;

        // Size of Value Watchpoint Variable
        public byte WPValueTriggerSize = 0;

        // Value of Value Watchpoint Variable
        public UInt32 WPValueTrigger = 0;

        enum CommandType
        {
            ConnectionStart,
            ReadMemory,
            ReadWatchpoints,
            SetWatchpoint,
            CleanWatchpoint,
            Resume,
            Unknown,
            BreakpointEvent,
        }

        CommandType AwaitingDataType = CommandType.Unknown;

        Queue<string> TxCommandsQueue = new Queue<string>();

        public OpenOCDClientClassB()
        {

            BackWorker.RunWorkerCompleted += ClientFail;
            BackWorker.DoWork += DoClientWork;
            CmdReadMemoryObj.DataParsingEndCallback += DataParsingEndCallback;
        }

        /// <summary>
        /// End of processing data block
        /// </summary>
        /// <param name="data"></param>
        void DataParsingEndCallback(byte[] data)
        {
            MemoryReadDataCallback?.Invoke(data);
            if (SetWatchpointsState == SetWatchpointsStateType.WaitForCaptureDone)
            {
                if (AutoCleanWatchPoint)
                {
                    System.Diagnostics.Debug.WriteLine("#Auto remove watchpoint!");
                    CommandCleanWatchpoint(SetWPAddress);
                    return;
                }
            }
        }

        public void StartClient()
        {
            BackWorker.RunWorkerAsync();
        }

        void DoClientWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    _cancellationSource = new CancellationTokenSource();
                    client = new TelnetClient("127.0.0.1", 4444, TimeSpan.FromMilliseconds(100), _cancellationSource.Token);
                    client.ConnectionClosed += HandleConnectionClosed;
                    client.MessageReceived += HandleMessageReceived;
                    client.Connect();

                    DateTime start = DateTime.Now;
                    while ((IsConnected == false) && ((DateTime.Now - start).TotalMilliseconds < 3000))
                    {
                    }

                    while ((client != null) && IsConnected)
                    {
                        if ((TxCommandsQueue.Count > 0) && ReadyForSend)
                        {
                            string txCommand = TxCommandsQueue.Dequeue();
                            ReadyForSend = false;
                            System.Diagnostics.Debug.WriteLine("TX: " + txCommand);
                            client.Send(txCommand + "\r\n");
                        }
                    }
                }
                catch (Exception)
                {
                    IsConnected = false;
                    // throw;
                }
            }
        }

        private void HandleMessageReceived(object sender, string message)
        {
            IsConnected = true;
            LinesReceived++;
            
            message = message.Replace("\0", string.Empty);
            if (message.Length == 0)
                return;

            System.Diagnostics.Debug.WriteLine("RX: " + message);

            if (message.Contains(">") && (message.Length < 5))
            {
                ReadyForSend = true;
            }
            else if (message.Contains("target halted due to debug-request"))
            {
                MCUHalted = true;
                if (SetWatchpointsState == SetWatchpointsStateType.WaitForHalt)
                {
                    SetWatchpointsState = SetWatchpointsStateType.WaitForWPSet;
                    AutoSetWatchpoint();
                }
            }
            else if (message.Contains("target halted due to breakpoint"))
            {
                MCUHalted = true;
                AwaitingDataType = CommandType.BreakpointEvent;
            }
            else if (message.Contains("mdb 0x"))
            {
                CmdReadMemoryObj.InitReadMemory(CmdReadMemorySize);
                AwaitingDataType = CommandType.ReadMemory;
            }
            else if (message.Contains("target not halted"))
            {
                MCUHalted = false;
            }
            else if (message.Contains("is not halted"))
            {
                //error detected
                MCUHalted = false;
                if (SetWatchpointsState != SetWatchpointsStateType.Idle)
                {
                    StartSetWatchpoint(SetWPAddress, AutoCleanWatchPoint);
                }
            }
            else if (message.Contains("msp:") || message.Contains("psp:"))
            {
                if ((SetWatchpointsState == SetWatchpointsStateType.WaitForWPSet) &&
                    (AwaitingDataType == CommandType.SetWatchpoint))
                {
                    WatchpointIsSet = true;
                    System.Diagnostics.Debug.WriteLine("#Start wait for watchpoint event!");
                    SetWatchpointsState = SetWatchpointsStateType.WaitForEvent;
                    CommandResumeMCU();
                }
                else if (AwaitingDataType == CommandType.BreakpointEvent)
                {
                    System.Diagnostics.Debug.WriteLine("#Detected watchpoint event!");
                    MCUHalted = true;
                    WatchpointEventDetected = true;
                    WatchpointIsSet = true;

                    if (SetWatchpointsState == SetWatchpointsStateType.WaitForEvent)
                    {
                        if (WPCaptureData)
                        {
                            SetWatchpointsState = SetWatchpointsStateType.WaitForCaptureDone;
                            CommandReadMemory(WPDataAddress, CmdReadMemorySize);
                        }
                        else if (AutoCleanWatchPoint)
                        {
                            System.Diagnostics.Debug.WriteLine("#Auto remove watchpoint!");
                            CommandCleanWatchpoint(SetWPAddress);
                            return;
                        }
                    }
                }
            }
            else if (message.Contains("> resume"))
            {
                MCUHalted = false;
            }
            else if (message.Contains("Failure setting watchpoints"))
            {
                //ERROR!
                CommandResumeMCU();
                AwaitingDataType = CommandType.Unknown;
            }
            else
            {
                if (AwaitingDataType == CommandType.ReadMemory)
                {
                    if (message.Length < 5)
                    {
                        AwaitingDataType = CommandType.Unknown;
                        return;
                    }
                    CmdReadMemoryObj.ParseLine(message);
                    return;
                }
                else if (AwaitingDataType == CommandType.CleanWatchpoint)
                {
                    //watchpoint is remowed - so we can run MCU
                    if (message.Contains("rwp 0x"))
                    {
                        AwaitingDataType = CommandType.Unknown;
                        CommandResumeMCU();
                        return;
                    }
                }
            }
        }

        void ClientFail(object sender, RunWorkerCompletedEventArgs e)
        {
            IsConnected = false;
        }

        private void HandleConnectionClosed(object sender, EventArgs eventArgs)
        {
            IsConnected = false;
        }

        //Commands
        //************************************************************************************
        public void CommandReadMemory(UInt32 startAddrBytes, UInt32 sizeBytes, bool ManualCall = false)
        {
            if (ManualCall == true)
                AutoCleanWatchPoint = false;

            CmdReadMemorySize = sizeBytes;
            string command = $"mdb 0x{startAddrBytes:X8}  {sizeBytes}";
            TxCommandsQueue.Enqueue(command);
        }

        /// <summary>
        /// Start process of setting and cleaning watchpoint
        /// </summary>
        /// <param name="startDataAddrBytes">Address of data source</param>
        /// <param name="sizeBytes">Data size in bytes</param>
        /// <param name="startTriggerAddrBytes">Write watchpoint address (1 byte size)</param>
        /// <param name="AutoClean">Auto clean watchpoint</param>
        public void StartWaitForData(UInt32 startDataAddrBytes, UInt32 sizeBytes, UInt32 startTriggerAddrBytes, bool AutoClean = true)
        {
            if (WatchpointIsSet)
                return;

            WPDataAddress = startDataAddrBytes;
            CmdReadMemorySize = sizeBytes;
            WPCaptureData = true;
            AutoSetValueWatchpoint = false;
            StartSetWatchpoint(startTriggerAddrBytes, AutoClean);
        }

        /// <summary>
        /// Start process of setting and cleaning value watchpoint
        /// </summary>
        /// <param name="startDataAddrBytes">Address of data source</param>
        /// <param name="sizeBytes">Data size in bytes</param>
        /// <param name="TriggerVarAddrBytes">Write watchpoint variable address</param>
        /// <param name="TriggerVarSize">Trigger variable size, bytes</param>
        /// <param name="TriggerVarValue">Trigger value</param>
        /// <param name="AutoClean">Auto clean watchpoint</param>
        public void StartWaitForTrigData(
            UInt32 startDataAddrBytes, 
            UInt32 sizeBytes, 
            UInt32 TriggerVarAddrBytes, 
            byte TriggerVarSize,
            UInt32 TriggerVarValue,
            bool AutoClean = true)
        {
            if (WatchpointIsSet)
                return;

            WPDataAddress = startDataAddrBytes;
            CmdReadMemorySize = sizeBytes;
            WPValueTrigger = TriggerVarValue;
            WPValueTriggerAddress = TriggerVarAddrBytes;
            WPValueTriggerSize = TriggerVarSize;

            AutoSetValueWatchpoint = true;
            WPCaptureData = true;
            StartSetWatchpoint(WPValueTriggerAddress, AutoClean);
        }

        //AutoClean - auto clean watchpoint after its event detected
        public void StartSetWatchpoint(UInt32 WatchpointAddrBytes, bool AutoClean = true)
        {
            WatchpointEventDetected = false;
            AutoCleanWatchPoint = AutoClean;
            SetWPAddress = WatchpointAddrBytes;
            SetWatchpointsState = SetWatchpointsStateType.Idle;

            if (MCUHalted == false)
            {
                SetWatchpointsState = SetWatchpointsStateType.WaitForHalt;
                CommandHaltMCU();
            }
            else
            {
                SetWatchpointsState = SetWatchpointsStateType.WaitForWPSet;
                AutoSetWatchpoint();
            }
        }

        /// <summary>
        /// Automaticly send command for setting watchpoint
        /// Mode is defined by "AutoSetValueWatchpoint"
        /// </summary>
        void AutoSetWatchpoint()
        {
            if (AutoSetValueWatchpoint)
                CommandSetValueWatchpoint(WPValueTriggerAddress, WPValueTriggerSize, WPValueTrigger);
            else
                CommandSetWatchpoint(SetWPAddress);
        }

        public void CommandHaltMCU()
        {
            string command = $"halt 0";//stop mcu for setting watchpoint
            TxCommandsQueue.Enqueue(command);
        }

        //AutoClean - auto clean watchpoint after its event detected
        public void CommandSetWatchpoint(UInt32 startAddrBytes)
        {
            AwaitingDataType = CommandType.SetWatchpoint;
            string command = $"wp 0x{startAddrBytes:X8}  1 w";//write access, 1 byte
            TxCommandsQueue.Enqueue(command);
        }

        //AutoClean - auto clean watchpoint after its event detected
        public void CommandSetValueWatchpoint(UInt32 startAddrBytes, byte dataSize, UInt32 value)
        {
            AwaitingDataType = CommandType.SetWatchpoint;
            string command = $"wp 0x{startAddrBytes:X8}  {dataSize} w {value}";//write access
            TxCommandsQueue.Enqueue(command);
        }

        public void CommandWPInfo()
        {
            string command = $"wp";
            TxCommandsQueue.Enqueue(command);
        }

        public void CommandResumeMCU()
        {
            string command = $"resume";//resume mcu from halt
            TxCommandsQueue.Enqueue(command);
        }

        public void CommandCleanWatchpoint(UInt32 startAddrBytes)
        {

            if (startAddrBytes == 0)
                return;
            string command;

            if (MCUHalted == false)
            {
                command = $"halt 0";//stop mcu for setting watchpoint
                TxCommandsQueue.Enqueue(command);
            }

            command = $"rwp 0x{startAddrBytes:X8}";//remove watchpoint

            WatchpointIsSet = false;
            AwaitingDataType = CommandType.CleanWatchpoint;
            TxCommandsQueue.Enqueue(command);
        }

    }//end of class
}
