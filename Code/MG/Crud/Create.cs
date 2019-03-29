using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopUtils.Core;
using DesktopUtils.Desktop.Models;

namespace DesktopUtils.Desktop.Crud
{
    public partial class Create : Form
    {
        private GenericRepositoryFiles<Club> repository { get; set; }
        private Club Club { get; set; }

        public Create(GenericRepositoryFiles<Club> repository)
        {
            InitializeComponent();
            this.Club = new Club();
            this.repository = repository;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            txtId.Text = Club.Id.ToString();
            txtName.Text = Club.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Club.Name = txtName.Text;
            repository.Add(Club);
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }
    }
}
