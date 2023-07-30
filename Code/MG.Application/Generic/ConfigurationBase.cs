
using MG.Application.Forms;

namespace MG.Application.Generic
{
    public abstract class ConfigurationBase : IConfiguration
    {
        public IConfigurationManager _configuration { get; set; }
        public List<ItemConfig> ItemConfigs { get; set; }
        public string Version { get => this.GetConfig("Version"); }
        public string TemplateDirectory { get => this.GetConfig("TemplateDirectory"); }
        public string ProjectName { get => this.GetConfig("ProjectName"); }
        
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

        public void AddConfig(ItemConfig ItemConfig, bool reload = true)
        {
            ItemConfig temp = null;

            if (ItemConfig.Id > 0)
            {
                temp = this.ItemConfigs.FirstOrDefault(p => p.Name == ItemConfig.Name || p.Id == ItemConfig.Id);
            }
            else
            {
                temp = this.ItemConfigs.FirstOrDefault(p => p.Name == ItemConfig.Name);
            }

            if (temp != null)
            {
                temp.Value = ItemConfig.Value;
                temp.IsChecked = false;
            }
            else
            {
                ItemConfigs.Add(ItemConfig);
            }

            if (reload)
            {
                ReadFromConfigFile();
                CreateDirectory();
            }
        }

        public void AddConfig(List<ItemConfig> ItemConfigs)
        {

            foreach (var item in ItemConfigs)
            {
                AddConfig(item, false);
            }

            ReadFromConfigFile();
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
            foreach (var item in this.ItemConfigs)
            {
                try
                {
                    if (!item.IsChecked)
                    {
                        item.IsChecked = true;
                        var p = _configuration.AppSettings[item.Name];
                        if (!string.IsNullOrEmpty(p))
                        {
                            item.Value = p;
                        }
                    }
                }
                catch (Exception e) { }

            }
        }

        public abstract List<IItemToReplace> GetItemToReplaces();
    }
}
