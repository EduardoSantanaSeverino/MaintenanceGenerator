using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class GenerateControlsBase : IGenerateControls
    {
        private IFrmMainApp _form { get; set; }

        private IConfiguration _configuration { get; set; }

        public GenerateControlsBase(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.ItemToReplaces = this._configuration.GetItemToReplaces();
        }

        public List<IItemToReplace> ItemToReplaces { get; private set; }

        public void AddInputControls(IFrmMainApp form)
        {
            this._form = form;
            foreach (var item in this.ItemToReplaces)
            {
                var group = new System.Windows.Forms.FlowLayoutPanel();
                group.Height = 27;
                group.Width = 326;
                group.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
                group.Margin = new System.Windows.Forms.Padding(0);
                group.Controls.Add(GetLabel(item));
                group.Controls.Add(GetTextBox(item));
                _form.FlowInput.Controls.Add(group);
            }
            _form.FlowInput.Controls.Add(GetSaveButton());
        }

        public void AddOutputControls()
        {
            foreach (var item in this._form.CrudGenerator.ItemFileToGenerates)
            {
                if (!string.IsNullOrEmpty(item.ControlName))
                {
                    _form.FlowOutput.Controls.Add(GetRichTextBox(item));
                }
            }
        }

        private System.Windows.Forms.Label GetLabel(IItemToReplace item)
        {
            var l = new System.Windows.Forms.Label
            {
                Name = "lbl" + item.Key,
                Text = item.LabelText,
                Width = 161,
                Height = 18,
                Margin = new System.Windows.Forms.Padding(0),
                TextAlign = System.Drawing.ContentAlignment.MiddleRight
            };
            return l;
        }

        private System.Windows.Forms.TextBox GetTextBox(IItemToReplace item)
        {
            var t = new System.Windows.Forms.TextBox
            {
                Name = item.Key,
                Text = item.Value,
                Width = 150,
                Height = 26,
                Margin = new System.Windows.Forms.Padding(0)
            };
            if (item.Id == 10)
            {
                t.TextChanged += new EventHandler(txtEntityNameSingular_TextChanged);
            }
            return t;
        }

        private System.Windows.Forms.Button GetSaveButton()
        {
            var b = new System.Windows.Forms.Button();
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.Name = "btnSaveOnDisk";
            b.Size = new System.Drawing.Size(75, 123);
            b.Text = "Save";
            b.UseVisualStyleBackColor = true;
            b.Margin = new System.Windows.Forms.Padding(0);
            b.Click += new System.EventHandler(this.btnSaveOnDisk_Click);
            return b;
        }

        private void txtEntityNameSingular_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var XXXEntityLowerSingularXXX = (System.Windows.Forms.TextBox)_form.FlowInput.Controls.Find("XXXEntityLowerSingularXXX", true)[0];
                var XXXEntityLowerPluralXXX = (System.Windows.Forms.TextBox)_form.FlowInput.Controls.Find("XXXEntityLowerPluralXXX", true)[0];
                var XXXEntityPluralXXX = (System.Windows.Forms.TextBox)_form.FlowInput.Controls.Find("XXXEntityPluralXXX", true)[0];
                var XXXEntitySingularXXX = (System.Windows.Forms.TextBox)_form.FlowInput.Controls.Find("XXXEntitySingularXXX", true)[0];

                string camell = "";
                var lower = XXXEntityLowerSingularXXX.Text;
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

                XXXEntityLowerPluralXXX.Text = camell;
                XXXEntityPluralXXX.Text = capital;
                XXXEntitySingularXXX.Text = capitalSingular;

                foreach (var item in ItemToReplaces)
                {
                    var c = this._form.FlowInput.Controls.Find(item.Key, true);
                    if (c != null && c.Any() && c[0].Name != XXXEntityLowerSingularXXX.Name)
                    {
                        item.Value = ((System.Windows.Forms.TextBox)c[0]).Text; ;
                    }
                }

                _form.CrudGenerator.SetItemToReplace(this.ItemToReplaces);

            }
            catch (Exception err)
            { }
        }

        private System.Windows.Forms.RichTextBox GetRichTextBox(IItemFileToGenerate item)
        {
            var l = new System.Windows.Forms.RichTextBox
            {
                Name = item.ControlName,
                Width = 380,
                Height = 68,
                Margin = new System.Windows.Forms.Padding(4),
                Text = item.TemplateMarkup
            };
            l.MouseClick += new System.Windows.Forms.MouseEventHandler(RichTextBoxGeneral_MouseClick);
            return l;
        }

        private void RichTextBoxGeneral_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            frmVisor vs = new frmVisor((System.Windows.Forms.RichTextBox)sender);
            vs.ShowDialog();
        }

        private void btnSaveOnDisk_Click(object sender, EventArgs e)
        {
            var btnSaveOnDisk = _form.FlowInput.Controls.Find("btnSaveOnDisk", true)[0];
            btnSaveOnDisk.Visible = false;
            try
            {
                _form.CrudGenerator.btnSaveOnDisk_Click();
                System.Windows.Forms.MessageBox.Show("Mantenimiento generado exitosamente");
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Surgió el siguiente error : " + err.Message);
            }
            System.Windows.Forms.Application.Exit();

        }
    }
}
