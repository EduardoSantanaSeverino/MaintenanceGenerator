using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public interface ICrudGenerator
    {
        IClassInfoData ClassInfoData { get; }

        IConfiguration Configuration { get; }

        string Version { get; }

        string TemplateDirectory { get; }

        string ProjectName { get; }

        List<IItemFileToGenerate> ItemFileToGenerates { get; }

        void SetItemToReplace(List<IItemToReplace> itemToReplaces);

        void AddComboParameter(ComboParameter comboParameter);

        void btnGenerate_Click(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces);

        void btnSaveOnDisk_Click();
    }
}
