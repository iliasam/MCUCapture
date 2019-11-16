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

        bool TriggerSelectionMode = false;

        public ELF_Form()
        {
            InitializeComponent();
            ELFParserObj = new ELFParserClass();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ELFParserObj.UpdateTableFromFile("test.out");
            UpdateTable();
        }

        void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < ELFParserObj.MemoryTable.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = ELFParserObj.MemoryTable[i].Name;
                dataGridView1.Rows[i].Cells[1].Value = "0x" + ELFParserObj.MemoryTable[i].Address.ToString("X");
                dataGridView1.Rows[i].Cells[2].Value = ELFParserObj.MemoryTable[i].Size;
                if (chkMarkFlash.Checked && AddressInFlash(ELFParserObj.MemoryTable[i].Address))
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Yellow;

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
            SelectedItem = ELFParserObj.MemoryTable[row];

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
    }
}
