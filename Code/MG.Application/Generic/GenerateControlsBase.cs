using MG.Application.Forms;

namespace MG.Application.Generic
{
    public abstract class GenerateControlsBase : IGenerateControls
    {
        protected IFrmMainApp _form { get; set; }

        protected IConfiguration _configuration { get; set; }
        
        public GenerateControlsBase(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void AddInputControls(IFrmMainApp form)
        {
            this._form = form;
            foreach (var item in this._configuration.GetItemToReplaces())
            {
                var group = new FlowLayoutPanel();
                // group.Height = 27;
                // group.Width = 326;
                // group.FlowDirection = FlowDirection.LeftToRight;
                // group.Margin = new Padding(0);
                group.Controls.Add(GetLabel(item));
                group.Controls.Add(GetTextBox(item));
                _form.FlowInput.Controls.Add(group);
            }
            // TODO: check if we really need save button?
            // _form.FlowInput.Controls.Add(GetSaveButton());
        }

        public void AddOutputControls()
        {
            foreach (var item in this._form.CrudGenerator.ItemFileToGenerates)
            {
                if (!string.IsNullOrEmpty(item.ControlName))
                {
                    var c = _form.FlowOutput.Controls.Find(p => p.Name == item.ControlName);
                    if (c != null)
                    {
                        c.Text = item.TemplateMarkup;
                    }
                    else
                    {
                        _form.FlowOutput.Controls.Add(GetRichTextBox(item));
                    }
                }
            }
        }

        private Label GetLabel(IItemToReplace item)
        {
            var l = new Label
            {
                Name = "lbl" + item.Key,
                Text = item.LabelText,
                // Width = 161,
                // Height = 18,
                // Margin = new Padding(0),
                // TextAlign = System.Drawing.ContentAlignment.MiddleRight
            };
            return l;
        }

        private TextBox GetTextBox(IItemToReplace item)
        {
            var t = new TextBox
            {
                Name = item.Key,
                Text = item.Value,
                // Width = 150,
                // Height = 26,
                // Margin = new Padding(0)
            };
            // if (item.Key == "XXXEntityLowerSingularXXX")
            // {
            //     t.TextChanged += new EventHandler(txtEntityNameSingular_TextChanged);
            // }
            return t;
        }

        // TODO: Check if we really need a save button
        // private Button GetSaveButton()
        // {
        //     var b = new Button();
        //     b.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //     b.Name = "btnSaveOnDisk";
        //     b.Size = new System.Drawing.Size(75, 123);
        //     b.Text = "Save";
        //     b.UseVisualStyleBackColor = true;
        //     b.Margin = new Padding(0);
        //     b.Click += new System.EventHandler(this.btnSaveOnDisk_Click);
        //     return b;
        // }

        public virtual void SetInputsFromParameters()
        {
            _form.CrudGenerator.Initialize();
            AddOutputControls();
        }

        private RichTextBox GetRichTextBox(IItemFileToGenerate item)
        {
            var l = new RichTextBox
            {
                Name = item.ControlName,
                Path = item.Path,
                // Width = 380,
                // Height = 68,
                // Margin = new Padding(4),
                Text = (string.IsNullOrEmpty(item.TemplateMarkup) ? item.Name : item.TemplateMarkup )
            };
            // l.MouseClick += new MouseEventHandler(RichTextBoxGeneral_MouseClick);
            return l;
        }

        // TODO: do we really need to mouse click?
        // private void RichTextBoxGeneral_MouseClick(object sender, MouseEventArgs e)
        // {
        //     frmVisor vs = new frmVisor((RichTextBox)sender);
        //     vs.ShowDialog();
        // }

        // TODO: do we really need to btnSaveOnDisk_Click?
        // private void btnSaveOnDisk_Click(object sender, EventArgs e)
        // {
        //     var btnSaveOnDisk = _form.FlowInput.Controls.Find("btnSaveOnDisk", true)[0];
        //     btnSaveOnDisk.Visible = false;
        //     try
        //     {
        //         _form.CrudGenerator.btnSaveOnDisk_Click();
        //         MessageBox.Show("Mantenimiento generado exitosamente");
        //     }
        //     catch (Exception err)
        //     {
        //         MessageBox.Show("Surgió el siguiente error : " + err.Message);
        //     }
        //     Application.Exit();
        //
        // }
    }
}
