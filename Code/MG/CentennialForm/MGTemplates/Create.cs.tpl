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

namespace DesktopUtils.Desktop.CrudXXXEntityPluralXXX
{
    public partial class Create : Form
    {
        private GenericRepositoryFiles<XXXEntitySingularXXX> repository { get; set; }
        private XXXEntitySingularXXX XXXEntitySingularXXX { get; set; }

        public Create(GenericRepositoryFiles<XXXEntitySingularXXX> repository)
        {
            InitializeComponent();
            this.XXXEntitySingularXXX = new XXXEntitySingularXXX();
            this.repository = repository;
        }

        private void Create_Load(object sender, EventArgs e)
        {
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
//XXXFieldsEdit2TplXXX
            repository.Add(XXXEntitySingularXXX);
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }
    }
}
