using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public interface IConfiguration
    {
        List<ItemConfig> ItemConfigs { get; set; }

        string Version { get; }

        string TemplateDirectory { get; }

        string ProjectName { get; }

        void CreateDirectory();

        void AddConfig(ItemConfig ItemConfig, bool reload = true);

        void AddConfig(List<ItemConfig> ItemConfigs);

        string GetConfig(int id);

        string GetConfig(string name);

        void ReadFromConfigFile();

        List<IItemToReplace> GetItemToReplaces();
    }
}
