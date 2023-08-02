namespace MG.Application.Generic
{
    public interface IConfiguration
    {
        List<ItemConfig> ItemConfigs { get; }

        string TemplateDirectory { get; }

        string ProjectName { get; }

        void CreateDirectory();

        void AddConfig(ItemConfig itemConfig, bool reload = true);

        void AddConfig(List<ItemConfig> itemConfigs);

        string GetConfig(int id);

        string GetConfig(string name);

        void ReadFromConfigFile();

        List<IItemToReplace> GetItemToReplaces();

        List<IItemToReplace> DefaultGetItemToReplaces { get; }

        void LateLoadingDefaultConfigs();
    }
}
