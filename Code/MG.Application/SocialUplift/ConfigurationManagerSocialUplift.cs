using MG.Application.Forms;

namespace MG.Application.SocialUplift;

public class ConfigurationManagerSocialUplift : IConfigurationManager
{
    public ConfigurationManagerSocialUplift()
    {
        this.AppSettings = new Dictionary<string, string>();
        // this.AppSettings.Add("SideBarFileName","header.js");
        // this.AppSettings.Add("TemplateDirectory", "SocialUplift\\MGTemplates\\".Replace('\\',Path.DirectorySeparatorChar));
        // this.AppSettings.Add("Version", "MaintenanceGenerator Ver. 3.0");
        // this.AppSettings.Add("ProjectName", "SocialUplift");
    }
    
    public Dictionary<string, string> AppSettings { get; set; }
}
