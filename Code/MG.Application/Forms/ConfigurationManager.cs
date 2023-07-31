using Microsoft.Extensions.Configuration;

namespace MG.Application.Forms;

public class ConfigurationManager : IConfigurationManager
{
    public ConfigurationManager()
    {
        this.AppSettings = new Dictionary<string, string>();
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfiguration config = builder.Build();

        var file = config.Get<AppSettingConfig>();

        if (file != null && file.AppSettings.Any())
        {
            foreach (var setting in file?.AppSettings)
            {
                if (setting.IsPath)
                {
                    setting.Value = setting.Value.Replace('\\', Path.DirectorySeparatorChar);
                }
                this.AppSettings.Add(setting.Name, setting.Value);
            }
        }
    }

    public Dictionary<string, string> AppSettings { get; set; }
    
    private class AppSettingConfig
    {
        public List<AppSettingItem> AppSettings { get; set; }
    }

    private class AppSettingItem
    {
        public AppSettingItem()
        {
        
        }
        public AppSettingItem(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
            this.IsPath = false;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsPath { get; set; }
    } 
    
}
