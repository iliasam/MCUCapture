using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUCapture
{
    /// <summary>
    /// Conversion of data
    /// </summary>
    class DataConversionClass
    {
        //one data item is containing several values
        public Int64[] ProcessDataItem(byte[] dataItemBytes, List<DataStructureItem> list, bool isBigEndian = false)
        {
            int offsetBytes = 0;
            int valueIndex = 0;
            Int64[] resultValues = new Int64[list.Count];//list.Count is a number of values

            while (offsetBytes < dataItemBytes.Length)
            {
                int CurrentValueSize = list[valueIndex].DataSize;
                byte[] ValueArray = new byte[CurrentValueSize];
                Array.Copy(dataItemBytes, offsetBytes, ValueArray, 0, CurrentValueSize);
                resultValues[valueIndex] = 
                    GetValue(ValueArray, list[valueIndex].IsSigned, CurrentValueSize, isBigEndian);
                offsetBytes += CurrentValueSize;
                valueIndex++;
            }
            return resultValues;
        }

        //take array of bytes and return Int64 value
        public Int64 GetValue(byte[] valueBytes, bool signed, int size, bool isBigEndian)
        {
            Int64 result = 0;
            //little endian is default in PC
            //cortex m3 is little endian
            if (isBigEndian)
                Array.Reverse(valueBytes); //reverse it so we get little endian - for PC

            if (signed)
            {
                if (size == 1)
                    result = (sbyte)valueBytes[0];
                if (size == 2)
                    result = BitConverter.ToInt16(valueBytes, 0);
                if (size == 4)
                    result = BitConverter.ToInt32(valueBytes, 0);
            }
            else
            {
                if (size == 1)
                    result = (byte)valueBytes[0];
                if (size == 2)
                    result = BitConverter.ToUInt16(valueBytes, 0);
                if (size == 4)
                    result = BitConverter.ToUInt32(valueBytes, 0);
            }
            return result;
        }
    }
}
