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
                string tmp_path = FileSavePath;
                if (chkAddTime.Checked)
                {
                    int tmp_pos = FileSavePath.Length - 4;
                    string extension = FileSavePath.Substring(tmp_pos, 4);

                    tmp_path = FileSavePath.Substring(0, tmp_pos);
                    tmp_path += "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + extension;
                    Invoke((MethodInvoker)(() =>
                    {
                        UpdateDisplayedFilename(tmp_path);
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        UpdateDisplayedFilename();
                    }));
                }

                BinaryWriter writer = new BinaryWriter(File.Open(tmp_path, FileMode.Create));
                writer.Write(rxData);
                writer.Close();
                SavedCounter++;
            }
            catch (Exception)
            {
                
            }
        }

        void UpdateDisplayedFilename(string path = "")
        {
            string visPath = FileSavePath;
            if (path.Length > 0)
                visPath = path;

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
