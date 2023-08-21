namespace MG.Application.Generic
{
    public interface ICrudGenerator
    {
        IClassInfoData ClassInfoData { get; }

        IConfiguration Configuration { get; }
        
        IItemFilePlaceHolderList ItemFilePlaceHolderList { get; }

        string Version { get; }

        string TemplateDirectory { get; }

        string ProjectName { get; }

        List<IItemFileToGenerate> ItemFileToGenerates { get; }
        
        void AddComboParameter(ComboParameter comboParameter);
        
        void Initialize();

        void SaveOnToDisk();
    }
}
