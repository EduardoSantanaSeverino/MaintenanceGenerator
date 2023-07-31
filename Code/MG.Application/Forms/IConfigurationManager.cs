namespace MG.Application.Forms;

public interface IConfigurationManager
{
    Dictionary<string, string> AppSettings { get; set; }
}