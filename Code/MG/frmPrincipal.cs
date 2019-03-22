using MG.MyCollege;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
                CrudGenerator.txtEntityNameSingular_TextChanged();
            }
            catch (Exception err)
            { }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            CrudGenerator.btnGenerate_Click();
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
            CrudGenerator.btnGenerate_Click(null, null);
        }

        private void txtRelateFieldValue_TextChanged(object sender, EventArgs e)
        {
            txtRelateFieldValue.BackColor = Color.White;
            if (txtRelateFieldValue.Text.Length == 0)
                return;

            if (CrudGenerator.ExistInFielList(txtRelateFieldValue.Text))
            {
                txtRelateFieldValue.BackColor = Color.Green;
                btnAgregarCombo.Enabled = true;
            }
            else if (!CrudGenerator.ExistInFielList(txtRelateFieldValue.Text))
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

            if (CrudGenerator.getFieldListFromEntity(txtRelateEntity.Text).Count == 0)
                txtRelateEntity.BackColor = Color.Red;
            else
                txtRelateEntity.BackColor = Color.Green;
        }

        private void txtRelateFieldDisplay_TextChanged(object sender, EventArgs e)
        {
            txtRelateFieldDisplay.BackColor = Color.White;
            if (txtRelateFieldDisplay.Text.Length == 0)
                return;


            if (CrudGenerator.ExistInRelatedFielList(txtRelateFieldDisplay.Text))
            {
                txtRelateFieldDisplay.BackColor = Color.Green;
                btnAgregarCombo.Enabled = true;
            }
            else if (!CrudGenerator.ExistInRelatedFielList(txtRelateFieldDisplay.Text))
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
