using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimS.Telnet;

namespace MCUCapture
{
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    class OpenOCDClientClass
    {
        Client client;
        BackgroundWorker BackWorker = new BackgroundWorker();//обеспечивает отдельный поток, который отвечает за прием данных

        enum CleanWatchpointsStateType
        {
            Idle,
            WaitForWPInfo,//wait for info received
            DoWPClean,
        }

        CleanWatchpointsStateType CleanWatchpointsState = CleanWatchpointsStateType.Idle;

        bool RxResultReceived = true;

        public bool IsConnected = false;

        UInt32 LastWPAddress = 0;

        public Action<byte[]> MemoryReadDataCallback;

        enum CommandType
        {
            ConnectionStart,
            ReadMemory,
            ReadWatchpoints,
            SetWatchpoint,
            CleanWatchpoint,
            Resume,
            Test,
        }

        struct TxCommandItem
        {
            public CommandType commandType;
            public string command;
        }

        Queue<TxCommandItem> TxCommandsQueue = new Queue<TxCommandItem>();

        public OpenOCDClientClass()
        {

            BackWorker.RunWorkerCompleted += ClientFail;
            BackWorker.DoWork += DoClientWork;
        }

        public void StartClient()
        {
            BackWorker.RunWorkerAsync();
        }

        public void StartCleanWatchpoints()
        {
            //clean
            TxCommandsQueue.Clear();
            WaitForData(CommandType.Test, 1.0);
            CommandReadWatchpoints();
            CleanWatchpointsState = CleanWatchpointsStateType.WaitForWPInfo;
        }

        public void CommandReadMemory(UInt32 startAddrBytes, UInt32 sizeBytes)
        {
            TxCommandItem command;
            command.commandType = CommandType.ReadMemory;
            command.command = $"mdb 0x{startAddrBytes:X8}  {sizeBytes}";
            //command.command = "mdb 0x08000000 64";
            TxCommandsQueue.Enqueue(command);
        }

        public void CommandSetWatchpoint(UInt32 startAddrBytes)
        {
            TxCommandItem command;

            command.commandType = CommandType.Test;
            command.command = $"halt 0";//stop mcu for setting watchpoint
            TxCommandsQueue.Enqueue(command);

            command.commandType = CommandType.SetWatchpoint;
            command.command = $"wp 0x{startAddrBytes:X8}  1 w";//write access, 1 byte
            TxCommandsQueue.Enqueue(command);

            CommandResumeMCU();//run programm - wait for interrupt
        }

        public void CommandCleanWatchpoint(UInt32 startAddrBytes)
        {
            TxCommandItem command;

            command.commandType = CommandType.Test;
            command.command = $"halt 0";//stop mcu for setting watchpoint
            TxCommandsQueue.Enqueue(command);

            command.commandType = CommandType.CleanWatchpoint;
            command.command = $"rwp 0x{startAddrBytes:X8}";//remove watchpoint
            TxCommandsQueue.Enqueue(command);
        }

        public void CommandResumeMCU()
        {
            TxCommandItem command;
            command.commandType = CommandType.Resume;
            command.command = $"resume";//resume mcu from halt
            TxCommandsQueue.Enqueue(command);
        }

        public void CommandReadWatchpoints()
        {
            TxCommandItem command;
            command.commandType = CommandType.ReadWatchpoints;
            command.command = $"wp";//request watchpoints list
            TxCommandsQueue.Enqueue(command);
        }

        void DoClientWork(object sender, DoWorkEventArgs e)//бесконечный цикл
        {
            while (true)
            {
                try
                {
                    client = new Client("127.0.0.1", 4444, new System.Threading.CancellationToken());
                    IsConnected = true;

                    while ((client != null) && client.IsConnected)
                    {
                        if ((TxCommandsQueue.Count > 0) && RxResultReceived)
                        {
                            TxCommandItem txCommandItem = TxCommandsQueue.Dequeue();
                            RxResultReceived = false;
                            client.WriteLine(txCommandItem.command);
                            Task<int> res = WaitForData(txCommandItem.commandType);
                            if (res.Result == -1)
                            {
                                client.Dispose();
                                break;
                            }
                        }

                        if (CleanWatchpointsState == CleanWatchpointsStateType.DoWPClean)
                        {
                            CommandCleanWatchpoint(LastWPAddress);
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

        void ClientFail(object sender, RunWorkerCompletedEventArgs e)
        {
            IsConnected = false;
        }

        async Task<int> WaitForData(CommandType cmdType, double timeout = 3.0)
        {
            while (true)
            {
                string rxData = await client.ReadAsync(TimeSpan.FromSeconds(timeout));

                if (rxData.Length == 0)
                    return -1;

                switch (cmdType)
                {
                    case CommandType.ReadMemory:
                        ParseReadMemoryCmd(rxData);
                        break;

                    case CommandType.Test:
                        break;

                    case CommandType.ReadWatchpoints:
                        ParseReadWatchpoints(rxData);
                        break;

                    case CommandType.CleanWatchpoint:
                        CommandResumeMCU();
                        CleanWatchpointsState = CleanWatchpointsStateType.Idle;
                        break;

                    default: break;
                }

                RxResultReceived = true;

                if ((rxData.Length < 25) && (cmdType == CommandType.ReadMemory))
                    continue;

                return 1;
            }
        }

        //wp\r\n\0address: 0x20000624, len: 0x00000001, r/w/a: 1, value: 0x00000000, mask: 0xffffffff\r\n\r\n\r> 
        void ParseReadWatchpoints(string rxData)
        {
            string[] array = rxData.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in array)
            {
                if (line.Contains("address:"))
                {
                    int addrStart = line.IndexOf(':') + 1;
                    int addrStop = line.IndexOf(',');
                    string addrStr = line.Substring(addrStart, addrStop - addrStart);
                    addrStr = addrStr.Trim();
                    LastWPAddress = Convert.ToUInt32(addrStr, 16);
                    CleanWatchpointsState = CleanWatchpointsStateType.DoWPClean;
                }
            }
        }



        void ParseReadMemoryCmd(string rxData)
        {
            List<byte> bytesList = new List<byte>();
            string[] array = rxData.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in array)
            {
                if (line.Contains("xPSR:"))
                    continue;
                if (line.Contains("0x") && line.Contains(":"))
                {
                    byte[] bytes = ParseHexMemoryData(line);
                    bytesList.AddRange(bytes);
                }
            }
            MemoryReadDataCallback?.Invoke(bytesList.ToArray());
        }
        //input string is like: "0x08000000: 40 04 00 20 a9 0a 00 08 ..."
        byte[] ParseHexMemoryData(string line)
        {
            int start = line.IndexOf(':') + 1;
            line = line.Substring(start, line.Length - start - 1);
            line = line.Trim();
            string[] bytesStr = line.Split(' ');
            byte[] bytes = new byte[bytesStr.Length];
            for (int i = 0; i < bytesStr.Length; i++)
            {
                bytes[i] = Convert.ToByte(bytesStr[i], 16);
            }

            return bytes;
        }

    }//end of class
}
