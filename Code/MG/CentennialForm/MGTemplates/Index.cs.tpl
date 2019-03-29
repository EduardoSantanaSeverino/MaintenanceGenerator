using DesktopUtils.Core;
using DesktopUtils.Desktop.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DesktopUtils.Desktop.CrudXXXEntityPluralXXX
{
    public partial class Index : Form
    {
        public GenericRepositoryFiles<XXXEntitySingularXXX> repository = new GenericRepositoryFiles<XXXEntitySingularXXX>();

        public Index()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            dataGridView1.AssignData(repository.List.ToArray());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var l = repository.List.Where(p => 
                        p.Name.Contains(txtSearch.Text.Trim())
                        ).ToArray();
                dataGridView1.AssignData(l);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dataGridView1.GetColumnName(e.ColumnIndex);
            if (columnName == "btnDetails")
            {
                var id = dataGridView1.GetRowValue(e.RowIndex, "cId");
                var XXXEntityLowerSingularXXX = repository.Get(int.Parse(id));
                var frmDetails = new CrudXXXEntityPluralXXX.Details(XXXEntityLowerSingularXXX);
                frmDetails.ShowDialog();
            }
            if (columnName == "btnEdit")
            {
                var id = dataGridView1.GetRowValue(e.RowIndex, "cId");
                var XXXEntityLowerSingularXXX = repository.Get(int.Parse(id));
                var frmDetails = new CrudXXXEntityPluralXXX.Edit(XXXEntityLowerSingularXXX, repository);
                if (frmDetails.ShowDialog() == DialogResult.Yes)
                {
                    dataGridView1.AssignData(repository.List.ToArray());
                }
            }
            if (columnName == "btnDelete")
            {
                var response = MessageBox.Show("Are you sure want to delete this row?", "Want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {
                    var id = dataGridView1.GetRowValue(e.RowIndex, "cId");
                    repository.Delete(int.Parse(id));
                    dataGridView1.AssignData(repository.List.ToArray());
                }
            }
        }

		private void btnCreate_Click(object sender, EventArgs e)
		{
			var frmCreate = new CrudXXXEntityPluralXXX.Create(repository);
			if (frmCreate.ShowDialog() == DialogResult.Yes)
			{
				dataGridView1.AssignData(repository.List.ToArray());
			}
		}
    }
}
