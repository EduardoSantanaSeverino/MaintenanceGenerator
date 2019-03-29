using DesktopUtils.Core;
using DesktopUtils.Desktop.Models;
using System;
using System.Windows.Forms;

namespace DesktopUtils.Desktop.CrudXXXEntityPluralXXX
{
    public partial class Edit : Form
    {
        private GenericRepositoryFiles<XXXEntitySingularXXX> repository { get; set; }
        private XXXEntitySingularXXX XXXEntitySingularXXX { get; set; }

        public Edit(XXXEntitySingularXXX XXXEntityLowerSingularXXX, GenericRepositoryFiles<XXXEntitySingularXXX> repository)
        {
            InitializeComponent();
            this.XXXEntitySingularXXX = XXXEntityLowerSingularXXX;
            this.repository = repository;
        }

        private void Edit_Load(object sender, EventArgs e)
        {

//XXXFieldsEdit1TplXXX

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
			
//XXXFieldsEdit2TplXXX

            repository.Update(XXXEntitySingularXXX);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
