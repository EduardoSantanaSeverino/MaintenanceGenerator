using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MG.Generic;
using MG.CentennialForm;

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

            var container = new WindsorContainer();

            // Register the CompositionRoot type with the container
            container.Register(Component.For<IClassInfoData>().ImplementedBy<ClassInfoData>());
            container.Register(Component.For<IConfiguration>().ImplementedBy<Configuration>());
            container.Register(Component.For<ICrudGenerator>().ImplementedBy<CrudGenerator>());
            container.Register(Component.For<IGenerateControls>().ImplementedBy<GenerateControls>());
            container.Register(Component.For<IItemFileToGenerate>().ImplementedBy<ItemFileToGenerate>());
            container.Register(Component.For<IItemToReplace>().ImplementedBy<ItemToReplace>());
           
            // Resolve an object of type ICompositionRoot (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            var crudGenerator = container.Resolve<ICrudGenerator>();
            var generateControls = container.Resolve<IGenerateControls>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainApp(crudGenerator, generateControls));
        }
    }
}
