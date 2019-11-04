using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimS.Telnet;

namespace MCUCapture
{
    class OpenOCDClientClass
    {
        Client client;
        BackgroundWorker BackWorker = new BackgroundWorker();//обеспечивает отдельный поток, который отвечает за прием данных
        bool RxResultReceived = true;

        public bool IsConnected = false;

        public Action<byte[]> MemoryReadDataCallback;

        enum CommandType
        {
            ConnectionStart,
            ReadMemory,
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

        public void CommandReadMemory(int startAddrBytes, int sizeBytes)
        {
            TxCommandItem command;
            command.commandType = CommandType.ReadMemory;
            command.command = $"mdb 0x{startAddrBytes:X8}  {sizeBytes}";
            //command.command = "mdb 0x08000000 64";
            TxCommandsQueue.Enqueue(command);
        }

        void DoClientWork(object sender, DoWorkEventArgs e)//бесконечный цикл
        {
            while (true)
            {
                try
                {
                    client = new Client("127.0.0.1", 4444, new System.Threading.CancellationToken());
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    WaitForData(CommandType.ConnectionStart);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
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

        async Task<int> WaitForData(CommandType cmdType)
        {
            while (true)
            {
                string rxData = await client.ReadAsync(TimeSpan.FromSeconds(3));

                if (rxData.Length == 0)
                    return -1;

                switch (cmdType)
                {
                    case CommandType.ReadMemory:
                        ParseReadMemoryCmd(rxData);
                        break;

                    case CommandType.Test:
                        break;

                    default: break;
                }

                RxResultReceived = true;

                if ((rxData.Length < 25) && (cmdType == CommandType.ReadMemory))
                    continue;

                return 1;
            }
        }

        void ParseReadMemoryCmd(string rxData)
        {
            List<byte> bytesList = new List<byte>();
            string[] array = rxData.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in array)
            {
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
