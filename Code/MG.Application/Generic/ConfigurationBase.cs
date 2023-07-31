
using MG.Application.Forms;

namespace MG.Application.Generic
{
    public abstract class ConfigurationBase : IConfiguration
    {
        public IConfigurationManager _configuration { get; set; }
        public List<ItemConfig> ItemConfigs { get; private set; } = new List<ItemConfig>();
        public string Version { get => this.GetConfig("Version"); }
        public string TemplateDirectory { get => this.GetConfig("TemplateDirectory").Replace('\\', Path.DirectorySeparatorChar); }
        public string ProjectName { get => this.GetConfig("ProjectName"); }

        public ConfigurationBase(IConfigurationManager configuration)
        {
            this._configuration = configuration;
            ReadFromConfigFile();
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

                    if (itemConfig.Value.Contains("#{") && itemConfig.Value.Contains("}"))
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

        public abstract List<IItemToReplace> GetItemToReplaces();
    }
}
