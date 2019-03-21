using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG
{
    public partial class frmVisor : Form
    {
        String texto = "";
        public frmVisor(RichTextBox richTextBoxOriginal)
        {
            InitializeComponent();
            texto = richTextBoxOriginal.Text;
        }

        private void frmVisor_Load(object sender, EventArgs e)
        {
            richTextBox1.Text =texto;
        }
    }
}
