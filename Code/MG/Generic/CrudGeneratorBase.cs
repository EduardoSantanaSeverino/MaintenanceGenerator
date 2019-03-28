using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class CrudGeneratorBase : ICrudGenerator
    {
        public IClassInfoData ClassInfoData { get; protected set; }
        public IConfiguration Configuration { get; protected set; }
        public string Version { get; protected set; }
        public string TemplateDirectory { get; protected set; }
        public string ProjectName { get; protected set; }

        public List<IItemFileToGenerate> ItemFileToGenerates { get; protected set; }

        public abstract void SetItemToReplace(List<IItemToReplace> itemToReplaces);

        public abstract void AddComboParameter(ComboParameter comboParameter);

        public abstract void btnGenerate_Click(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces);

        public void btnSaveOnDisk_Click()
        {
            foreach (var item in this.ItemFileToGenerates)
            {
                createSpecificFileOnDisk(item.Path, item.TemplateMarkup);
            }
            System.Threading.Thread.Sleep(1000);
        }

        protected void createSpecificFileOnDisk(string fileName, string containerText)
        {
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            System.IO.File.AppendAllText(fileName, containerText);
        }
    }
}
