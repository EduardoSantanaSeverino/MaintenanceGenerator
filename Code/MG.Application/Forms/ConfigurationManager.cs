namespace MG.Application.Forms;

public class ConfigurationManager : IConfigurationManager
{
    public ConfigurationManager()
    {
        this.AppSettings = new Dictionary<string, string>();
        this.AppSettings.Add("SideBarFileName","header.js");
        this.AppSettings.Add("TemplateDirectory", "MGTemplates\\");
        this.AppSettings.Add("Version", "MaintenanceGenerator Ver. 3.0");
        this.AppSettings.Add("ProjectName", "VoiceIt");
    }

    public Dictionary<string, string> AppSettings { get; set; }
}
