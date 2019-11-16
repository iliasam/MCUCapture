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
        public ELF_Form()
        {
            InitializeComponent();
            ELFParserObj = new ELFParserClass();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ELFParserObj.UpdateTableFromFile("test.out");
        }
    }
}
