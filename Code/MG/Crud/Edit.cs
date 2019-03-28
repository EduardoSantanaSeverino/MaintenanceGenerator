using DesktopUtils.Core;
using DesktopUtils.Desktop.Models;
using System;
using System.Windows.Forms;

namespace DesktopUtils.Desktop.Crud
{
    public partial class Edit : Form
    {
        private GenericRepositoryFiles<Club> repository { get; set; }
        private Club Club { get; set; }

        public Edit(Club club, GenericRepositoryFiles<Club> repository)
        {
            InitializeComponent();
            this.Club = club;
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
            repository.Update(Club);
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }
    }
}
