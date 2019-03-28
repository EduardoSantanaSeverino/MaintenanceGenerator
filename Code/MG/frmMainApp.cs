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
    public partial class frmMainApp : Form
    {
        public MyCollege.CrudGenerator CrudGenerator { get; set; }
        public MyCollege.GenerateControls GenerateControls { get; set; }
        public frmMainApp()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var config = new MyCollege.Configuration();
            this.CrudGenerator = new MyCollege.CrudGenerator(config, config.GetItemToReplaces());
            this.GenerateControls = new MyCollege.GenerateControls(config.GetItemToReplaces(), this);
            this.GenerateControls.AddInputControls();
            this.GenerateControls.AddOutputControls();
        }

        private void frmMainApp_Load(object sender, EventArgs e)
        {
            this.Text = CrudGenerator.Version;
        }

        private void flowInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
