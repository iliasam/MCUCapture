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
        OpenOCDClientClassB OpenOCDClientObj;
        ELF_Form ELF_FormObj;

        int DataReceivedCnt = 0;

        //openocd -d2 -f interface/stlink.cfg -f target/stm32f4x.cfg
        public Form1()
        {
            InitializeComponent();
            OpenOCDClientObj = new OpenOCDClientClassB();
            OpenOCDClientObj.MemoryReadDataCallback += MemoryReadDataForm;
            lblDataReceivedCnt.Text = $"| Data RX Cnt: {0}";
            lblSelectedELFItem.Text = $"| Selected ELF Item: N/A";
            lblSelectedTriggerELFItem.Text = $"| Curr. Trigger ELF Item: N/A";
        }

        //callback from openocd client
        void MemoryReadDataForm(byte[] rxData)
        {
            plotControl1.ProcessData(rxData, chkIsBigEndian.Checked);

            DataReceivedCnt++;
            Invoke((MethodInvoker)(() =>
            {
                lblDataReceivedCnt.Text = $"| Data RX Cnt: {DataReceivedCnt}";
            }));
        }

        //called from timer
        void UpdateGUI()
        {
            if (OpenOCDClientObj.IsConnected)
                lblConnectionSate.Text = "Connection: OK";
            else
                lblConnectionSate.Text = "Connection: Fail";
            lblLinesReceived.Text = $"| Lines RX: {OpenOCDClientObj.LinesReceived}";

            if (OpenOCDClientObj.MCUHalted)
                lblHaltState.Text = "| MCU: Halted";
            else
                lblHaltState.Text = "| MCU: Run";


            if (OpenOCDClientObj.WatchpointIsSet)
                lblWatchpointActive.Text = "| Watchpoint: Set";
            else
                lblWatchpointActive.Text = "| Watchpoint: No";
        }

        void ReadMemoryData()
        {
            try
            {
                UInt32 dataSize = Convert.ToUInt32(txtBoxDataSize.Text);
                UInt32 dataAddress = Convert.ToUInt32(txtBoxDataStartAddr.Text, 16);
                OpenOCDClientObj.CommandReadMemory(dataAddress, dataSize, true);
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

        //wait for buffer end watchpoint
        private void btnWaitEndWatchpoint_Click(object sender, EventArgs e)
        {
            UInt32 dataSize = Convert.ToUInt32(txtBoxDataSize.Text);
            UInt32 dataAddress = Convert.ToUInt32(txtBoxDataStartAddr.Text, 16);
            OpenOCDClientObj.StartWaitForData(dataAddress, dataSize, dataSize + dataAddress - 1);
        }

        private void btnResumeMCU_Click(object sender, EventArgs e)
        {
           OpenOCDClientObj.CommandResumeMCU();
        }


        private void btnCleanWatchpoints_Click(object sender, EventArgs e)
        {
            OpenOCDClientObj.CommandCleanWatchpoint(OpenOCDClientObj.SetWPAddress);
        }

        private void btnHaltMCU_Click(object sender, EventArgs e)
        {
            OpenOCDClientObj.CommandHaltMCU();
        }

        void OpenELFForm()
        {
            if (ELF_FormObj == null)
                ELF_FormObj = new ELF_Form();

            if (ELF_FormObj.IsDisposed)
                ELF_FormObj = new ELF_Form();

            ELF_FormObj.DataSelectedAction += DataSelectedActionForm;
            ELF_FormObj.TriggerSelectedAction += TriggerSelectedActionForm;
            ELF_FormObj.Show();
        }

        //calback from elf selecting window. Called when data selection is complete
        void DataSelectedActionForm(ELFParserClass.MemoryTableItem selectedItem)
        {
            txtBoxDataStartAddr.Text = "0x" + selectedItem.Address.ToString("X");
            txtBoxDataSize.Text = selectedItem.Size.ToString();
            lblSelectedELFItem.Text = $"| Curr. ELF Item: \"{selectedItem.Name}\"";
        }

        //calback from elf selecting window. Called when data selection is complete
        void TriggerSelectedActionForm(ELFParserClass.MemoryTableItem selectedItem)
        {
            txtBoxTriggerAddr.Text = "0x" + selectedItem.Address.ToString("X");
            comboBoxTrigSize.Text = selectedItem.Size.ToString();
            lblSelectedTriggerELFItem.Text = $"| Curr. Trigger ELF Item: \"{selectedItem.Name}\"";
        }

        private void btnTakeDataFromELF_Click(object sender, EventArgs e)
        {
            OpenELFForm();
            ELF_FormObj.PrepareForDataSelection();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            plotControl1.SaveSettings();
            System.Threading.Thread.Sleep(200);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenOCDClientObj.CommandSetValueWatchpoint(0x20001428, 4, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenOCDClientObj.CommandWPInfo(); ;
        }

        private void btnWaitForTrigger_Click(object sender, EventArgs e)
        {
            UInt32 dataAddress = Convert.ToUInt32(txtBoxDataStartAddr.Text, 16);
            UInt32 dataSize = Convert.ToUInt32(txtBoxDataSize.Text);

            byte varSize = Convert.ToByte(comboBoxTrigSize.Text);
            UInt32 varAddress = Convert.ToUInt32(txtBoxTriggerAddr.Text, 16);
            UInt32 varValue = Convert.ToUInt32(txtBoxTriggerValue.Text);

            OpenOCDClientObj.StartWaitForTrigData(dataAddress, dataSize, varAddress, varSize, varValue);
        }

        private void btnTaketriggerAddressFromELF_Click(object sender, EventArgs e)
        {
            OpenELFForm();
            ELF_FormObj.PrepareForTriggerSelection();
        }
    }
}
