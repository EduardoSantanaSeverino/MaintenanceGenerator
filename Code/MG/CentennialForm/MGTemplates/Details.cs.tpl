﻿using DesktopUtils.Desktop.Models;
using System;
using System.Windows.Forms;

namespace DesktopUtils.Desktop.CrudXXXEntityPluralXXX
{
    public partial class Details : Form
    {
        private XXXEntitySingularXXX XXXEntitySingularXXX { get; set; }
        public Details(XXXEntitySingularXXX XXXEntitySingularXXX)
        {
            InitializeComponent();
            this.XXXEntitySingularXXX = XXXEntitySingularXXX;
        }

        private void Details_Load(object sender, EventArgs e)
        {
			
//XXXFieldsDetailsTplXXX

        }
    }
}
