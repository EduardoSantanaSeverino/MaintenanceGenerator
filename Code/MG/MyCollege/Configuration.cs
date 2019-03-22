using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class Configuration
    {
        public List<ItemConfig> ItemConfigs { get; set; }
        public string Version = "MaintenanceGenerator Ver. 2.2";
        public string TemplateDirectory = @"MGTemplates\";
        public string ProjectName = "MYCOLLEGE";

        public Configuration()
        {
            ItemConfigs = new List<ItemConfig>()
            {
                new ItemConfig { Id = 10, Name = "AuthorizationDirectory", Value = ProjectName + @".Core\Authorization" },
                new ItemConfig { Id = 20, Name = "ViewsDirectory", Value = ProjectName + @".Web\App\Main\views\" },
                new ItemConfig { Id = 30, Name = "WebMainDirectory", Value = ProjectName + @".Web\App\Main\" },
                new ItemConfig { Id = 40, Name = "WebDirectory", Value = ProjectName + @".Web\" },
                new ItemConfig { Id = 50, Name = "ClassesPath", Value = ProjectName + @".Core\Models\" },
                new ItemConfig { Id = 60, Name = "DtosPath", Value = ProjectName + @".Application\" },
                new ItemConfig { Id = 70, Name = "SideBarFileName", Value = "header.js" },
                new ItemConfig { Id = 80, Name = "pathDirectoryApp", Value = ProjectName + @".Application\" }
            };
        }

        public void AddConfig(ItemConfig ItemConfig)
        {
            ItemConfigs.Add(ItemConfig);
        }

        public string GetConfig(int id)
        {
            var retVal = ItemConfigs.FirstOrDefault(p => p.Id == id);
            if (retVal != null)
                return retVal.Value;

            return ""; 
        }

        public string GetConfig(string name)
        {
            var retVal = ItemConfigs.FirstOrDefault(p => p.Name == name);
            if (retVal != null)
                return retVal.Value;

            return "";
        }

    }
}
