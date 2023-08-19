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
                new ItemConfig { Name = "ApplicationDirectory", Value =  @"#{XXXProjectDirectoryXXX}\aspnet-core\src\#{XXXProjectNameXXX}.Application\", IsPath = true},
                new ItemConfig { Name = "AuthorizationDirectory", Value = @"#{XXXProjectDirectoryXXX}\aspnet-core\src\#{XXXProjectNameXXX}.Core\Authorization\", IsPath = true },
                new ItemConfig { Name = "AngularAppDirectory", Value = @"#{XXXProjectDirectoryXXX}\angular\src\app\", IsPath = true },
                new ItemConfig { Name = "AngularSharedDirectory", Value = @"#{XXXProjectDirectoryXXX}\angular\src\shared\", IsPath = true },
                new ItemConfig { Name = "ClassesPath", Value = @"#{XXXProjectDirectoryXXX}\aspnet-core\src\#{XXXProjectNameXXX}.Core\Models\", IsPath = true },
            };

            this.AddConfig(_itemConfigs);
        }
    }
}
