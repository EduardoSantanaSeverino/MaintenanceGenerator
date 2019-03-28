using MG.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG
{
    public partial class frmMainApp : Form, IFrmMainApp
    {
        public ICrudGenerator CrudGenerator { get; set; }
        public IGenerateControls GenerateControls { get; set; }
       
        public frmMainApp(ICrudGenerator crudGenerator, IGenerateControls generateControls)
        {
            InitializeComponent();
            this.CrudGenerator = crudGenerator;
            this.GenerateControls = generateControls;
            this.GenerateControls.AddInputControls(this);
            this.GenerateControls.AddOutputControls();
        }

        private void frmMainApp_Load(object sender, EventArgs e)
        {
            this.Text = CrudGenerator.Version;
        }

        public FlowLayoutPanel FlowInput { get => this.flowInput; set => this.flowInput = value; }
        public FlowLayoutPanel FlowOutput { get => this.flowOutput; set => this.flowOutput = value; }

    }
}
