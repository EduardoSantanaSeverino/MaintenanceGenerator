using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class ConfigurationBase : IConfiguration
    {
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
                        var p = ConfigurationManager.AppSettings[item.Name];
                        if (!string.IsNullOrEmpty(p))
                        {
                            item.Value = p;
                        }
                    }
                }
                catch (Exception e) { }

            }
        }

        public virtual List<IItemToReplace> GetItemToReplaces()
        {
            return new List<IItemToReplace>
            {
                new ItemToReplace
                {
                    Id = 10,
                    Key = "XXXEntityPluralXXX",
                    LabelText = "Enity name singular camel case"
                },
                new ItemToReplace
                {
                    Id = 11,
                    Key = "XXXEntityLowerPluralXXX",
                    LabelText = "Enity name singular capital case"
                },
                new ItemToReplace
                {
                    Id = 12,
                    Key = "XXXEntitySingularXXX",
                    LabelText = "Enity name plural camel case"
                },
                new ItemToReplace
                {
                    Id = 13,
                    Key = "XXXEntityLowerSingularXXX",
                    LabelText = "Enity name plural capital case"
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
    }
}
