using MG.Application.Forms;

namespace MG.Application.Generic
{
    public abstract class ConfigurationBase : IConfiguration
    {
        public IConfigurationManager _configuration { get; set; }
        public List<ItemConfig> ItemConfigs { get; private set; } = new List<ItemConfig>();
        public string TemplateDirectory { get => this.GetConfig("TemplateDirectory").Replace('\\', Path.DirectorySeparatorChar); }
        public string ProjectName { get => this.GetConfig("ProjectName"); }

        public ConfigurationBase(IConfigurationManager configuration)
        {
            this._configuration = configuration;
            this.LoadDefaultConfigs();
            this.ReadFromConfigFile();
        }
        
        public void CreateDirectory()
        {
            foreach (var item in this.ItemConfigs)
            {
                if (item.CreateDirectory)
                {
                    if (!System.IO.Directory.Exists(item.Value))
                    {
                        System.IO.Directory.CreateDirectory(item.Value);
                    }
                }
            }
        }

        public void AddConfig(ItemConfig itemConfig, bool reload = true)
        {
            ItemConfig temp = null;

            if (itemConfig.Id > 0)
            {
                temp = this.ItemConfigs.FirstOrDefault(p => p.Name == itemConfig.Name || p.Id == itemConfig.Id);
            }
            else
            {
                temp = this.ItemConfigs.FirstOrDefault(p => p.Name == itemConfig.Name);
            }

            if (temp != null)
            {
                temp.Value = itemConfig.Value;
                temp.IsChecked = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(itemConfig.Value))
                {
                    if (itemConfig.IsPath)
                    {
                        itemConfig.Value = itemConfig.Value.Replace('\\', Path.DirectorySeparatorChar);
                    }

                    while (itemConfig.Value.Contains("#{") && itemConfig.Value.Contains("}"))
                    {
                        int startIndex = itemConfig.Value.IndexOf("#{") + 2; // Adding 2 to exclude "#{"
                        int endIndex = itemConfig.Value.IndexOf("}");
                    
                        if (startIndex < endIndex)
                        {
                            string replaceConfigName = itemConfig.Value.Substring(startIndex, endIndex - startIndex);
                            string replaceWith = this.GetConfig(replaceConfigName);
                            if (!string.IsNullOrEmpty(replaceWith))
                            {
                                itemConfig.Value = itemConfig.Value.Replace("#{" + replaceConfigName + "}", replaceWith);
                            }
                        }
                    }

                    var itemToReplace = this.DefaultGetItemToReplaces.FirstOrDefault(p => p.Key == itemConfig.Name);
                    if (itemToReplace != null)
                    {
                        itemToReplace.Value = itemConfig.Value;
                        if (itemConfig.Name == "XXXEntityLowerSingularXXX")
                        {
                            this.SetEntityNames(itemToReplace.Value);
                        }
                    }
                }

                ItemConfigs.Add(itemConfig);

            }

            if (reload)
            {
                CreateDirectory();
            }
        }

        public void AddConfig(List<ItemConfig> itemConfigs)
        {

            foreach (var item in itemConfigs)
            {
                AddConfig(item, false);
            }

            CreateDirectory();
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
            var retVal = ItemConfigs.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            if (retVal != null)
                return retVal.Value;

            return "";
        }

        public void ReadFromConfigFile()
        {
            foreach (var item in _configuration.AppSettings)
            {
                var loadedConfig = this.ItemConfigs.FirstOrDefault(p => p.Name == item.Key);
                if (loadedConfig != null)
                {
                    if (!loadedConfig.IsChecked)
                    {
                        loadedConfig.IsChecked = true;
                        loadedConfig.Value = item.Value;
                    }
                }
                else
                {
                    this.AddConfig(new ItemConfig() { Name = item.Key, Value = item.Value }, false);
                }
            }
        }

        private void LoadDefaultConfigs()
        {
            this.AddConfig(new ItemConfig() { Name = "Version", Value = "VERSION_PLACE_HOLDER", IsChecked = true}, false);
            this.AddConfig(new ItemConfig() { Name = "TemplateDirectory", Value = "MGTemplates\\", IsPath = true }, false);
            this.AddConfig(new ItemConfig() { Name = "ProjectName", Value = "NO_PROJECT_NAME_DEFINED" }, false);
            this.AddConfig(new ItemConfig() { Name = "ProjectDirectory", Value = "/src-default", IsPath = true }, false);
        }

        public virtual void LateLoadingDefaultConfigs()
        {
            
        }

        public virtual List<IItemToReplace> DefaultGetItemToReplaces { get; } = new List<IItemToReplace>
        {
            new ItemToReplaceBase
            {
                Id = 13,
                Key = "XXXEntityLowerSingularXXX",
                LabelText = "Enity name singular lower case"
            },
            new ItemToReplaceBase
            {
                Id = 12,
                Key = "XXXEntitySingularXXX",
                LabelText = "Enity name plural capital case"
            },
            new ItemToReplaceBase
            {
                Id = 11,
                Key = "XXXEntityLowerPluralXXX",
                LabelText = "Enity name pural lower case"
            },
            new ItemToReplaceBase
            {
                Id = 10,
                Key = "XXXEntityPluralXXX",
                LabelText = "Enity name singular capital case"
            },
            new ItemToReplaceBase
            {
                Id = 14,
                Key = "XXXProjectNameXXX",
                LabelText = "Project Name",
            },
            new ItemToReplaceBase
            {
                Id = 13,
                Key = "XXXSpecificTypeXXX",
                LabelText = "Specific Type",
                Value = ""
            }
        };
    
        public virtual List<IItemToReplace> GetItemToReplaces()
        {
            return this.DefaultGetItemToReplaces;
        }

        public virtual void SetEntityNames(string XXXEntityLowerSingularXXX)
        {
            var XXXEntityLowerPluralXXX = this.DefaultGetItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntityLowerPluralXXX");
            var XXXEntityPluralXXX = this.DefaultGetItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntityPluralXXX");
            var XXXEntitySingularXXX = this.DefaultGetItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntitySingularXXX");

            string camell = "";
            var lower = XXXEntityLowerSingularXXX.ToLower();
            if (lower.Substring(lower.Length - 1, 1) == "s")
                camell = lower + "es";
            else if (lower.Substring(lower.Length - 1, 1) == "y" &&
                     (
                         (lower.Substring(lower.Length - 2, 1) != "a") &&
                         (lower.Substring(lower.Length - 2, 1) != "e") &&
                         (lower.Substring(lower.Length - 2, 1) != "i") &&
                         (lower.Substring(lower.Length - 2, 1) != "o") &&
                         (lower.Substring(lower.Length - 2, 1) != "u")
                     )
                    )
            {
                camell = lower.Substring(0, lower.Length - 1) + "ies";
            }
            else
                camell = lower + "s";

            var capital = camell.Substring(0, 1).ToUpper() + camell.Substring(1);
            var capitalSingular = lower.Substring(0, 1).ToUpper() + lower.Substring(1);

            XXXEntityLowerPluralXXX.Value = camell;
            XXXEntityPluralXXX.Value= capital;
            XXXEntitySingularXXX.Value = capitalSingular;
        }
    }
}
