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
    public partial class ELF_Form : Form
    {

        ELFParserClass ELFParserObj;
        ELFParserClass.MemoryTableItem SelectedItem;

        public Action<ELFParserClass.MemoryTableItem> DataSelectedAction;
        public Action<ELFParserClass.MemoryTableItem> TriggerSelectedAction;

        bool DataLoaded = false;
        string NameFilter = "";

        bool TriggerSelectionMode = false;

        public ELF_Form()
        {
            InitializeComponent();
            ELFParserObj = new ELFParserClass();
        }

        public void PrepareForDataSelection()
        {
            TriggerSelectionMode = false;
            this.Text = "Data Source Selection";
        }

        public void PrepareForTriggerSelection()
        {
            TriggerSelectionMode = true;
            this.Text = "Trigger Source Selection";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string path = "";
            openFileDialog1.Filter = "elf (*.elf)|*.elf|out (*.out)|*.out|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                ProcessFile(path);

            }
            else
            {
                MessageBox.Show("Impossible to open file: " + path, "ERROR!", 0, System.Windows.Forms.MessageBoxIcon.Stop);
            }
        }

        void ProcessFile(string path)
        {
            // ELFParserObj.UpdateTableFromFile("test.out");

            string visPath = path;
            if (visPath.Length > 60)
                visPath = "..." + visPath.Substring(visPath.Length - 60, 60);

            toolTip1.SetToolTip(lblFileName, path);
            lblFileName.Text = "File Name: " + visPath;

            ELFParserObj.UpdateTableFromFile(path);
            DataLoaded = true;
            UpdateTable();
        }

        void UpdateTable()
        {
            if (DataLoaded == false)
                return;

            dataGridView1.Rows.Clear();

            int RowCnt = 0;
            for (int i = 0; i < ELFParserObj.MemoryTable.Count; i++)
            {
                if (NameFilter.Length > 0)
                {
                    if (ELFParserObj.MemoryTable[i].Name.Contains(NameFilter) == false)
                        continue; //skip this name
                }

                dataGridView1.Rows.Add();
                dataGridView1.Rows[RowCnt].Cells[0].Value = i;
                dataGridView1.Rows[RowCnt].Cells[1].Value = ELFParserObj.MemoryTable[i].Name;
                dataGridView1.Rows[RowCnt].Cells[2].Value = "0x" + ELFParserObj.MemoryTable[i].Address.ToString("X");
                dataGridView1.Rows[RowCnt].Cells[3].Value = ELFParserObj.MemoryTable[i].Size;
                if (chkMarkFlash.Checked && AddressInFlash(ELFParserObj.MemoryTable[i].Address))
                    dataGridView1.Rows[RowCnt].Cells[2].Style.BackColor = Color.Yellow;

                RowCnt++;
            }
            dataGridView1.Refresh();
        }

        bool AddressInFlash(UInt64 address)
        {
            if ((address >= 0x08000000) && (address <= 0x09000000))
                return true;
            else
                return false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int listIndex = (int)dataGridView1.Rows[row].Cells[0].Value;//dirty
            SelectedItem = ELFParserObj.MemoryTable[listIndex];

            lblSelectedName.Text = $"Name: {SelectedItem.Name}";
            lblSelectedAddress.Text = $"Address: 0x{SelectedItem.Address:X}";
            lblSelectedSize.Text = $"Size: {SelectedItem.Size} bytes";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (TriggerSelectionMode)
                TriggerSelectedAction?.Invoke(SelectedItem);
            else
                DataSelectedAction?.Invoke(SelectedItem);
            this.Close();
        }

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            NameFilter = txtNameFilter.Text;

            if (DataLoaded == false)
                return;

            UpdateTable();
        }
    }
}
