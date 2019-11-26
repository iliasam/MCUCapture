using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MCUCapture
{
    public partial class DataSavingControl : UserControl
    {

        //Full path including name
        string FileSavePath = "";

        int SavedCounter = 0;

        public DataSavingControl()
        {
            InitializeComponent();
        }

        //select filename
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Binary file|*.bin|All files|*.*";
            saveFileDialog1.Title = "Select file for saving data";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                if (FileSavePath != saveFileDialog1.FileName)
                {
                    FileSavePath = saveFileDialog1.FileName;
                    SavedCounter = 0;
                    UpdateDisplayedFilename();
                }
            }
        }


        public void SaveData(byte[] rxData)
        {
            try
            {
                BinaryWriter writer = new BinaryWriter(File.Open(FileSavePath, FileMode.Create));
                writer.Write(rxData);
                writer.Close();
                SavedCounter++;
            }
            catch (Exception)
            {
                
            }
        }

        void UpdateDisplayedFilename()
        {
            string visPath = FileSavePath;
            if (visPath.Length > 60)
                visPath = "..." + visPath.Substring(visPath.Length - 60, 60);
            lblSelectedFileName.Text = "File Name: " + visPath;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSaveCounter.Text = $"Save Counter: {SavedCounter}";
        }
    }//end of class
}
