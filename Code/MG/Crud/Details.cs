using DesktopUtils.Desktop.Models;
using System;
using System.Windows.Forms;

namespace DesktopUtils.Desktop.Crud
{
    public partial class Details : Form
    {
        private Club Club { get; set; }
        public Details(Club club)
        {
            InitializeComponent();
            this.Club = club;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            txtId.Text = Club.Id.ToString();
            txtId.Enabled = false;
            txtName.Text = Club.Name;
            txtName.Enabled = false;
        }
    }
}
