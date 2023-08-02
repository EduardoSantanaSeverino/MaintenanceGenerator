using MG.Application.Forms;
using MG.Application.Generic;

namespace MG.Application.SocialUplift
{
    public class Configuration : ConfigurationBase, IConfiguration
    {
        
        public Configuration() : base(new ConfigurationManager())
        {
        }

        public override void LateLoadingDefaultConfigs()
        {
            List<ItemConfig> _itemConfigs = null;

            _itemConfigs = new List<ItemConfig>()
            {
                new ItemConfig { Name = "ApplicationDirectory", Value =  @"#{ProjectDirectory}\aspnet-core\src\#{ProjectName}.Application\", IsPath = true},
                new ItemConfig { Name = "AuthorizationDirectory", Value = @"#{ProjectDirectory}\aspnet-core\src\#{ProjectName}.Core\Authorization\", IsPath = true },
                new ItemConfig { Name = "AngularAppDirectory", Value = @"#{ProjectDirectory}\angular\src\app\", IsPath = true },
                new ItemConfig { Name = "AngularSharedDirectory", Value = @"#{ProjectDirectory}\angular\src\shared\", IsPath = true },
                new ItemConfig { Name = "ClassesPath", Value = @"#{ProjectDirectory}\aspnet-core\src\#{ProjectName}.Core\Models\", IsPath = true },
            };

            this.AddConfig(_itemConfigs);
        }
    }
}
