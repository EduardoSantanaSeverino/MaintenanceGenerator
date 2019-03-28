using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MG.MyCollege;
using MG.Generic;

namespace MG
{
    public partial class frmPrincipal : Form
    {
        private CrudGenerator CrudGenerator { get; set; }

        public frmPrincipal(CrudGenerator CrudGenerator)
        {
            InitializeComponent();
            this.CrudGenerator = CrudGenerator;
        }

        private void txtEntityNameSingular_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string camell = "";
                var lower = txtCamelSingular.Text;
                if (lower.ToLower().Substring(lower.Length - 1, 1) == "s")
                    camell = lower + "es";
                else if (lower.ToLower().Substring(lower.Length - 1, 1) == "y" &&
                    (
                        (lower.ToLower().Substring(lower.Length - 2, 1) != "a") &&
                        (lower.ToLower().Substring(lower.Length - 2, 1) != "e") &&
                        (lower.ToLower().Substring(lower.Length - 2, 1) != "i") &&
                        (lower.ToLower().Substring(lower.Length - 2, 1) != "o") &&
                        (lower.ToLower().Substring(lower.Length - 2, 1) != "u")
                    )
                    )
                {
                    camell = lower.Substring(0, lower.Length - 1) + "ies";
                }
                else
                    camell = lower + "s";

                var capital = camell.Substring(0, 1).ToUpper() + camell.Substring(1);
                var capitalSingular = lower.Substring(0, 1).ToUpper() + lower.Substring(1);

                txtCamelPlural.Text = camell;
                txtCapitalPlural.Text = capital;
                txtCapitalSingular.Text = capitalSingular;

                btnGenerate_Click(null, null);
            }
            catch (Exception err)
            { }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var config = new MyCollege.Configuration();
            var itemsToReplace = new List<ItemToReplace>
                {
                    new ItemToReplace
                    {
                        Key = "XXXEntityPluralXXX",
                        Value = txtCapitalPlural.Text
                    },
                    new ItemToReplace
                    {
                        Key = "XXXEntityLowerPluralXXX",
                        Value = txtCamelPlural.Text
                    },
                    new ItemToReplace
                    {
                        Key = "XXXEntitySingularXXX",
                        Value = txtCapitalSingular.Text
                    },
                    new ItemToReplace
                    {
                        Key = "XXXEntityLowerSingularXXX",
                        Value = txtCamelSingular.Text
                    },new ItemToReplace
                    {
                        Key = "XXXProjectNameXXX",
                        Value = config.ProjectName
                    }
                };

            CrudGenerator.btnGenerate_Click(config, itemsToReplace);

            foreach (var item in CrudGenerator.ItemFileToGenerates)
            {
                var c = this.Controls.Find(item.ControlName, true);
                if (c != null && c.Any())
                {
                    ((RichTextBox)c[0]).Text = item.TemplateMarkup;
                }
            }

        }

        private void btnSaveOnDisk_Click(object sender, EventArgs e)
        {
            btnSaveOnDisk.Visible = false;
            try
            {
                CrudGenerator.btnSaveOnDisk_Click();
                MessageBox.Show("Mantenimiento generado exitosamente");
            }
            catch (Exception err)
            {
                MessageBox.Show("Surgió el siguiente error : " + err.Message);
            }
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtProjectName.Text = CrudGenerator.ProjectName;
            lbxCombos.Items.Clear();
            this.Text = CrudGenerator.Version;
            txtCamelSingular.Focus();
        }

        private void RichTextBoxGeneral_MouseClick(object sender, MouseEventArgs e)
        {
            frmVisor vs = new frmVisor((RichTextBox)sender);
            vs.ShowDialog();
        }

        private void btnAgregarCombo_Click(object sender, EventArgs e)
        {

            if (txtRelateFieldDisplay.BackColor == Color.Red)
                return;
            if (txtRelateFieldValue.BackColor == Color.Red)
                return;
            if (txtRelateEntity.BackColor == Color.Red)
                return;

            if (string.IsNullOrEmpty(txtRelateEntity.Text) ||
                string.IsNullOrEmpty(txtRelateFieldDisplay.Text) ||
                string.IsNullOrEmpty(txtRelateFieldValue.Text))
            {
                MessageBox.Show("Debe completar todos los campos de la entidad relacionda");
                return;
            }

            ComboParameter cbp = new ComboParameter(txtRelateEntity.Text, txtRelateFieldValue.Text, txtRelateFieldDisplay.Text);
            lbxCombos.Items.Add(cbp);

            txtRelateEntity.Clear();
            txtRelateFieldDisplay.Clear();
            txtRelateFieldValue.Clear();
            btnGenerate_Click(null, null);
        }

        private void txtRelateFieldValue_TextChanged(object sender, EventArgs e)
        {
            txtRelateFieldValue.BackColor = Color.White;
            if (txtRelateFieldValue.Text.Length == 0)
                return;

            if (CrudGenerator.ClassInfoData.ExistInFielList(txtRelateFieldValue.Text))
            {
                txtRelateFieldValue.BackColor = Color.Green;
                btnAgregarCombo.Enabled = true;
            }
            else if (!CrudGenerator.ClassInfoData.ExistInFielList(txtRelateFieldValue.Text))
            {
                txtRelateFieldValue.BackColor = Color.Red;
                btnAgregarCombo.Enabled = false;
            }
        }

        private void txtRelateEntity_TextChanged(object sender, EventArgs e)
        {
            txtRelateEntity.BackColor = Color.White;
            if (txtRelateEntity.Text.Length == 0)
                return;

            if (CrudGenerator.ClassInfoData.GetFieldListFromEntity(txtRelateEntity.Text).Count == 0)
                txtRelateEntity.BackColor = Color.Red;
            else
                txtRelateEntity.BackColor = Color.Green;
        }

        private void txtRelateFieldDisplay_TextChanged(object sender, EventArgs e)
        {
            txtRelateFieldDisplay.BackColor = Color.White;
            if (txtRelateFieldDisplay.Text.Length == 0)
                return;

            if (CrudGenerator.ClassInfoData.ExistInRelatedFielList(txtRelateFieldDisplay.Text, txtRelateEntity.Text))
            {
                txtRelateFieldDisplay.BackColor = Color.Green;
                btnAgregarCombo.Enabled = true;
            }
            else if (!CrudGenerator.ClassInfoData.ExistInRelatedFielList(txtRelateFieldDisplay.Text, txtRelateEntity.Text))
            {
                txtRelateFieldDisplay.BackColor = Color.Red;
                btnAgregarCombo.Enabled = false;
            }
        }

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            txtCamelSingular.Focus();
        }
    }
}
