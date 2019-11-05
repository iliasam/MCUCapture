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

        public OpenOCDClientClassB()
        {

            BackWorker.RunWorkerCompleted += ClientFail;
            BackWorker.DoWork += DoClientWork;
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
                            TxCommandItem txCommandItem = TxCommandsQueue.Dequeue();
                            ReadyForSend = false;
                            client.Send(txCommandItem.command + "\r\n");
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

            if (message.Contains(">"))
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

        public void CommandReadMemory(UInt32 startAddrBytes, UInt32 sizeBytes)
        {
            TxCommandItem command;
            command.commandType = CommandType.ReadMemory;
            command.command = $"mdb 0x{startAddrBytes:X8}  {sizeBytes}";
            TxCommandsQueue.Enqueue(command);
        }

    }//end of class
}
