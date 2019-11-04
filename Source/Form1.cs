using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCUCapture
{
    public partial class Form1 : Form
    {
        OpenOCDClientClass OpenOCDClientObj;

        //openocd -d2 -f interface/stlink.cfg -f target/stm32f4x.cfg
        public Form1()
        {
            InitializeComponent();
            OpenOCDClientObj = new OpenOCDClientClass();
            OpenOCDClientObj.MemoryReadDataCallback += MemoryReadDataForm;
            
        }

        //callback from openocd client
        void MemoryReadDataForm(byte[] rxData)
        {
            plotControl1.ProcessData(rxData, chkIsBigEndian.Checked);
        }

        //called from timer
        void UpdateGUI()
        {
            if (OpenOCDClientObj.IsConnected)
                lblConnectionSate.Text = "Connection: OK";
            else
                lblConnectionSate.Text = "Connection: Fail";
        }

        void ReadMemoryData()
        {
            try
            {
                int dataSize = Convert.ToInt32(txtBoxDataSize.Text);
                int dataAddress = Convert.ToInt32(txtBoxDataStartAddr.Text, 16);
                OpenOCDClientObj.CommandReadMemory(dataAddress, dataSize);
            }
            catch (Exception)
            {

                // throw;
            }
        }

        //*****************************************************************


        private void button1_Click(object sender, EventArgs e)
        {
            OpenOCDClientObj.CommandReadMemory(0x08000000, 128);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            OpenOCDClientObj.StartClient();
            timerUpdateGUI.Enabled = true;
        }

        private void timerUpdateGUI_Tick(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        private void btnManualRead_Click(object sender, EventArgs e)
        {
            ReadMemoryData();
        }
    }
}
