using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TentacleSoftware.Telnet;

namespace MCUCapture
{
    class OpenOCDClientClassB
    {
        TelnetClient client;
        public bool IsConnected = false;
        BackgroundWorker BackWorker = new BackgroundWorker();
        CancellationTokenSource _cancellationSource;
        bool ReadyForSend = true;

        public int LinesReceived = 0;

        UInt32 CmdReadMemorySize = 0;//not good solution

        CmdReadMemoryClass CmdReadMemoryObj = new CmdReadMemoryClass();

        public Action<byte[]> MemoryReadDataCallback;

        public bool MCUHalted = false;

        bool WatchpointEventDetected = false;
        bool AutoCleanWatchPoint = true;

        //Address of last received Watchpoint
        public UInt32 LastWPAddress = 0;

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

        void DataParsingEndCallback(byte[] data)
        {
            MemoryReadDataCallback?.Invoke(data);
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

            if (message.Contains("mdb 0x"))
            {
                CmdReadMemoryObj.InitReadMemory(CmdReadMemorySize);
                AwaitingDataType = CommandType.ReadMemory;
                return;
            }

            if (message.Contains("target not halted"))
            {
                MCUHalted = false;
                return;
            }

            //received async message that watchpoint event happend
            if (message.Contains("target halted"))
            {
                MCUHalted = true;
                AwaitingDataType = CommandType.BreakpointEvent;
                return;
            }

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
            else if (AwaitingDataType == CommandType.BreakpointEvent)
            {
                if (message.Contains("msp:"))
                {
                    System.Diagnostics.Debug.WriteLine("Dtected watpoint event!");
                    MCUHalted = true;
                    WatchpointEventDetected = true;
                    //ReadyForSend = true;
                    if (AutoCleanWatchPoint)
                    {
                        CommandCleanWatchpoint(LastWPAddress);
                        return;
                    }
                }
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

            if (message.Contains(">") && (message.Length < 5))
                ReadyForSend = true;
        }

        void ClientFail(object sender, RunWorkerCompletedEventArgs e)
        {
            IsConnected = false;
        }

        private void HandleConnectionClosed(object sender, EventArgs eventArgs)
        {
           // _cancellationSource.Cancel();
            IsConnected = false;
        }

        //Commands
        //************************************************************************************
        public void CommandReadMemory(UInt32 startAddrBytes, UInt32 sizeBytes)
        {
            CmdReadMemorySize = sizeBytes;
            string command = $"mdb 0x{startAddrBytes:X8}  {sizeBytes}";
            TxCommandsQueue.Enqueue(command);
        }

        //AutoClean - auto clean watchpoint after its event detected
        public void CommandSetWatchpoint(UInt32 startAddrBytes, bool AutoClean = true)
        {
            WatchpointEventDetected = false;
            LastWPAddress = startAddrBytes;
            AutoCleanWatchPoint = AutoClean;
            string command = $"halt 0";//stop mcu for setting watchpoint
            TxCommandsQueue.Enqueue(command);

            command = $"wp 0x{startAddrBytes:X8}  1 w";//write access, 1 byte
            TxCommandsQueue.Enqueue(command);

            CommandResumeMCU();//run programm - wait for interrupt
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

            //command  = $"halt 0";//stop mcu for setting watchpoint
            //TxCommandsQueue.Enqueue(command);

            command = $"rwp 0x{startAddrBytes:X8}";//remove watchpoint

            AwaitingDataType = CommandType.CleanWatchpoint;
            TxCommandsQueue.Enqueue(command);
        }

    }//end of class
}
