using MG.Application.Forms;
using MG.Application.Generic;

namespace MG.Application.SocialUplift
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
        
        public Configuration() : base(new ConfigurationManager())
        {

            string projectName = "SocialUplift";

            try { projectName = _configuration.AppSettings["ProjectName"]; } catch (Exception ex) {}

            List<ItemConfig> _itemConfigs = null;
            
            // _itemConfigs = new List<ItemConfig>()
            // {
            //     new ItemConfig { Name = "ProjectName", Value = projectName},
            //     new ItemConfig { Name = "Version", Value = "MaintenanceGenerator Ver. 3.0" },
            //     new ItemConfig { Name = "TemplateDirectory", Value = @"#{ProjectName}\MGTemplates\", IsPath = true },
            //     new ItemConfig { Name = "MenuIcon", Value = "fa-home" }
            // };
            //
            // this.AddConfig(_itemConfigs);
            
            _itemConfigs = new List<ItemConfig>()
            {
                new ItemConfig { Name = "ApplicationDirectory", Value =  @"#{ProjectName}\aspnet-core\src\#{ProjectName}.Application\", IsPath = true},
                new ItemConfig { Name = "AuthorizationDirectory", Value = @"#{ProjectName}\aspnet-core\src\#{ProjectName}.Core\Authorization\", IsPath = true },
                new ItemConfig { Name = "AngularAppDirectory", Value = @"#{ProjectName}\angular\src\app\", IsPath = true },
                new ItemConfig { Name = "AngularSharedDirectory", Value = @"#{ProjectName}\angular\src\shared\", IsPath = true },
                new ItemConfig { Name = "ClassesPath", Value = @"#{ProjectName}\aspnet-core\src\#{ProjectName}.Core\Models\", IsPath = true },
            };

            this.AddConfig(_itemConfigs);
            
        } 
    }
}
