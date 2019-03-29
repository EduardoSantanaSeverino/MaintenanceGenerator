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

        public void btnSaveOnDisk_Click()
        {
            foreach (var item in this.ItemFileToGenerates)
            {
                createSpecificFileOnDisk(item.Path, item.TemplateMarkup);
            }
            System.Threading.Thread.Sleep(1000);
        }

        protected abstract void Initialize(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces);

        protected abstract void LoadItemFileToCreate();

        protected void createSpecificFileOnDisk(string fileName, string containerText)
        {
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            System.IO.File.AppendAllText(fileName, containerText);
        }

        public virtual void SetItemToReplace(List<IItemToReplace> itemToReplaces)
        {
            Initialize(this.Configuration, itemToReplaces);
        }

        public virtual void AddComboParameter(ComboParameter comboParameter)
        {
            this.ClassInfoData.AddComboParameter(comboParameter);
            LoadItemFileToCreate();
        }

        public virtual void btnGenerate_Click(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces)
        {
            Initialize(Configuration, ItemToReplaces);
        }

    }
}
