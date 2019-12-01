using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUCapture
{
    /// <summary>
    /// Pasring received data
    /// </summary>
    class CmdReadMemoryClass
    {
        List<byte> bytesList = new List<byte>();
        UInt32 EstimatedSize = 0;

        /// <summary>
        /// Called whien all estimated data is prosessed
        /// </summary>
        public Action<byte[]> DataParsingEndCallback;

        public void InitReadMemory(UInt32 sizeBytes)
        {
            bytesList = new List<byte>();
            EstimatedSize = sizeBytes;
        }

        public void ParseLine(string rxData)
        {
            if (rxData.Contains("0x") && rxData.Contains(":"))
            {
                byte[] bytes = ParseHexMemoryData(rxData);
                bytesList.AddRange(bytes);
            }

            if (bytesList.Count == EstimatedSize)
            {
                DataParsingEndCallback?.Invoke(bytesList.ToArray());
            }
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
