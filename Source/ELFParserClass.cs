using System;
using System.Collections.Generic;
using System.IO;

using ELFSharp.ELF;
using ELFSharp.ELF.Sections;

namespace MCUCapture
{
    public class ELFParserClass
    {

        public struct MemoryTableItem
        {
            public string Name;
            public UInt32 Address;//start addess
            public UInt32 Size;//bytes
        }

        public List<MemoryTableItem> MemoryTable = new List<MemoryTableItem>();

        public void UpdateTableFromFile(string path)
        {
            if ((path == null) || (path == ""))
                return;
            if (File.Exists(path) == false)
                return;

            ISymbolTable symtab;
            try
            {
                var elf = ELFReader.Load(path);
                symtab = (ISymbolTable)elf.GetSection(".symtab");
            }
            catch (Exception)
            {
                return;
            }

            MemoryTable = new List<MemoryTableItem>();
            foreach (var item in symtab.Entries)
            {
                string str = item.ToString();
                if (str.Contains("Global Object"))
                {
                    MemoryTableItem memItem = ExtractDataFromString(str);
                    if (memItem.Size > 0)
                    {
                        MemoryTable.Add(memItem);
                        Console.WriteLine(str);
                    }
                    
                }
                    
            }
        }

        //string is like "Global Object test_data: 0x20000428, size: 4096, section idx: 8"
        MemoryTableItem ExtractDataFromString(string str)
        {
            MemoryTableItem newItem;

            int nameBegin = str.IndexOf("Object") + 7;
            int nameEnd = str.IndexOf(':', nameBegin);
            newItem.Name = str.Substring(nameBegin, nameEnd - nameBegin);

            int adrBegin = str.IndexOf("0x");
            int adrEnd = str.IndexOf(',', adrBegin);
            string addr = str.Substring(adrBegin, adrEnd - adrBegin);
            newItem.Address = Convert.ToUInt32(addr, 16);

            int sizeBegin = str.IndexOf("size:") + 6;
            int sizeEnd = str.IndexOf(',', sizeBegin);
            string size = str.Substring(sizeBegin, sizeEnd- sizeBegin);
            newItem.Size = Convert.ToUInt32(size);

            return newItem;
        }

    }//end of class
}
