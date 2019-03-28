using MG.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.CentennialForm
{
    public class Configuration : ConfigurationBase, IConfiguration
    {
        public override List<IItemToReplace> GetItemToReplaces()
        {
            return new List<IItemToReplace>
            {
                new ItemToReplace
                {
                    Id = 10,
                    Key = "XXXEntityPluralXXX",
                    LabelText = "Enity name singular capital case"
                },
                new ItemToReplace
                {
                    Id = 11,
                    Key = "XXXEntityLowerPluralXXX",
                    LabelText = "Enity name pural camel case"
                },
                new ItemToReplace
                {
                    Id = 12,
                    Key = "XXXEntitySingularXXX",
                    LabelText = "Enity name plural capital case"
                },
                new ItemToReplace
                {
                    Id = 13,
                    Key = "XXXEntityLowerSingularXXX",
                    LabelText = "Enity name singular camel case"
                },
                new ItemToReplace
                {
                    Id = 14,
                    Key = "XXXProjectNameXXX",
                    LabelText = "Project Name",
                    Value = this.ProjectName
                },
                new ItemToReplace
                {
                    Id = 15,
                    Key = "XXXMenuIconXXX",
                    LabelText = "Fa Icon",
                    Value = GetConfig("MenuIcon")
                }
            };
        }

        public Configuration()
        {
            ItemConfigs = new List<ItemConfig>()
            {
                new ItemConfig { Id = 100, Name = "ProjectName", Value = "Crud Gene 2" },
                new ItemConfig { Id = 102, Name = "Version", Value = "MaintenanceGenerator Ver. 2.2" },
                new ItemConfig { Id = 103, Name = "TemplateDirectory", Value = @"CentennialFormTemplates\" },
                new ItemConfig { Id = 104, Name = "MenuIcon", Value = "fa-home" }
            };

            ReadFromConfigFile();

            ItemConfigs.AddRange(new List<ItemConfig>()
            {
                new ItemConfig { Id = 250, Name = "ClassesPath", Value =  @"Models\" },
                new ItemConfig { Id = 270, Name = "PathDirectoryApp", Value = @"" },
            });

            ReadFromConfigFile();
            CreateDirectory();

        }

    }
}
