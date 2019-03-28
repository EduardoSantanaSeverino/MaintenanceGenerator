using MG.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class Configuration : ConfigurationBase, IConfiguration
    {
        public List<ItemConfig> ItemConfigs { get; set; }
        public string Version { get => this.GetConfig("Version"); }
        public string TemplateDirectory { get => this.GetConfig("TemplateDirectory"); }
        public string ProjectName { get => this.GetConfig("ProjectName"); }

        public Configuration()
        {
            ItemConfigs = new List<ItemConfig>()
            {
                new ItemConfig { Id = 100, Name = "ProjectName", Value = "MYCOLLEGE" },
                new ItemConfig { Id = 101, Name = "SideBarFileName", Value = "header.js" },
                new ItemConfig { Id = 102, Name = "Version", Value = "MaintenanceGenerator Ver. 2.2" },
                new ItemConfig { Id = 103, Name = "TemplateDirectory", Value = @"MGTemplates\" },
                new ItemConfig { Id = 104, Name = "MenuIcon", Value = "fa-home" }
            };

            ReadFromConfigFile();

            ItemConfigs.AddRange(new List<ItemConfig>()
            {
                new ItemConfig { Id = 210, Name = "AuthorizationDirectory", Value =  this.ProjectName  + @".Core\Authorization" },
                new ItemConfig { Id = 220, Name = "ViewsDirectory", Value =  this.ProjectName  + @".Web\App\Main\views\" },
                new ItemConfig { Id = 230, Name = "WebMainDirectory", Value =  this.ProjectName  + @".Web\App\Main\" },
                new ItemConfig { Id = 240, Name = "WebDirectory", Value =  this.ProjectName  + @".Web\" },
                new ItemConfig { Id = 250, Name = "ClassesPath", Value =  this.ProjectName  + @".Core\Models\" },
                new ItemConfig { Id = 260, Name = "DtosPath", Value =  this.ProjectName  + @".Application\" },
                new ItemConfig { Id = 270, Name = "PathDirectoryApp", Value =  this.ProjectName  + @".Application\" },
            });

            ReadFromConfigFile();

            ItemConfigs.AddRange(new List<ItemConfig>()
            {
                new ItemConfig
                {
                    Name = "AuthorizationProviderFile",
                    Value = GetConfig("AuthorizationDirectory") + @"\" + this.ProjectName + "AuthorizationProvider.cs"
                },
                new ItemConfig
                {
                    Name = "PermissionNamesFile",
                    Value = GetConfig("AuthorizationDirectory") + @"\PermissionNames.cs"
                },
                new ItemConfig
                {
                    Name = "AppJsFile",
                    Value = GetConfig("WebMainDirectory") + @"app.js"
                },
                new ItemConfig
                {
                    Name = "NavigationProviderFile",
                    Value = GetConfig("WebDirectory") + @"App_Start\" + this.ProjectName + "NavigationProvider.cs"
                },
                new ItemConfig
                {
                    Name = "NavBarJSFile",
                    Value = GetConfig("ViewsDirectory") + @"layout\" + GetConfig("SideBarFileName")
                }
            });

            ReadFromConfigFile();
            CreateDirectory();

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
                catch (Exception e) {}
                
            }
        }

        public List<ItemToReplace> GetItemToReplaces()
        {
            return new List<ItemToReplace>
            {
                new MyCollege.ItemToReplace
                {
                    Id = 10,
                    Key = "XXXEntityPluralXXX",
                    LabelText = "Enity name singular camel case"
                },
                new MyCollege.ItemToReplace
                {
                    Id = 11,
                    Key = "XXXEntityLowerPluralXXX",
                    LabelText = "Enity name singular capital case"
                },
                new MyCollege.ItemToReplace
                {
                    Id = 12,
                    Key = "XXXEntitySingularXXX",
                    LabelText = "Enity name plural camel case"
                },
                new MyCollege.ItemToReplace
                {
                    Id = 13,
                    Key = "XXXEntityLowerSingularXXX",
                    LabelText = "Enity name plural capital case"
                },
                new MyCollege.ItemToReplace
                {
                    Id = 14,
                    Key = "XXXProjectNameXXX",
                    LabelText = "Project Name",
                    Value = this.ProjectName
                },
                new MyCollege.ItemToReplace
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
