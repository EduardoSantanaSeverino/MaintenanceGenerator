using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainApp());
         //   Application.Run(new frmPrincipal(new MyCollege.CrudGenerator(new MyCollege.Configuration(), new List<MyCollege.ItemToReplace>())));
        }
    }
}
