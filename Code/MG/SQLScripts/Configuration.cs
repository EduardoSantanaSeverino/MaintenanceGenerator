using MG.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MG.SQLScripts
{
    public class Configuration : ConfigurationBase, IConfiguration
    {
        public override List<IItemToReplace> GetItemToReplaces()
        {
            return new List<IItemToReplace>
            {
                new ItemToReplace
                {
                    Id = 13,
                    Key = "XXXEntityLowerSingularXXX",
                    LabelText = "Enity name singular lower case"
                },
                new ItemToReplace
                {
                    Id = 12,
                    Key = "XXXEntitySingularXXX",
                    LabelText = "Enity name plural capital case"
                },
                 new ItemToReplace
                {
                    Id = 11,
                    Key = "XXXEntityLowerPluralXXX",
                    LabelText = "Enity name pural lower case"
                },
                new ItemToReplace
                {
                    Id = 10,
                    Key = "XXXEntityPluralXXX",
                    LabelText = "Enity name singular capital case"
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
                    Id = 13,
                    Key = "XXXSpecificTypeXXX",
                    LabelText = "Specific Type",
                    Value = ""
                }
            };
        }

        public Configuration()
        {

            string projectName = "SocialUplift";

            try { projectName = ConfigurationManager.AppSettings["ProjectName"]; } catch (Exception ex) {}
            ItemConfigs = new List<ItemConfig>()
            {
                new ItemConfig { Name = "ProjectName", Value = projectName },
                new ItemConfig { Name = "Version", Value = "MaintenanceGenerator Ver. 2.3" },
                new ItemConfig { Name = "TemplateDirectory", Value = @"MGTemplates\" },
                new ItemConfig { Name = "MenuIcon", Value = "fa-home" }
            };

            ItemConfigs.AddRange(new List<ItemConfig>()
            {
                new ItemConfig { Name = "ApplicationDirectory", Value =  $@"{projectName}\aspnet-core\src\{projectName}.Application\" },
                new ItemConfig { Name = "AuthorizationDirectory", Value = $@"{projectName}\aspnet-core\src\{projectName}.Core\Authorization\" },
                new ItemConfig { Name = "AngularAppDirectory", Value = $@"{projectName}\angular\src\app\" },
                new ItemConfig { Name = "AngularSharedDirectory", Value = $@"{projectName}\angular\src\shared\" },
                new ItemConfig { Name = "ClassesPath", Value = $@"{projectName}\aspnet-core\src\{projectName}.Core\Models\" },
            });

            ReadFromConfigFile();
            CreateDirectory();

        }
    }
}
