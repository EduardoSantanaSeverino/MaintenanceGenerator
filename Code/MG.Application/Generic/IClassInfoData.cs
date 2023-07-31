namespace MG.Application.Generic
{
    public interface IClassInfoData
    {
        string XXXEntityPluralXXX { get; } // txtCapitalPlural.Text

        string XXXEntityLowerPluralXXX { get; } // txtCamelPlural.Text

        string XXXEntitySingularXXX { get; } //  txtCapitalSingular.Text);

        string XXXEntityLowerSingularXXX { get; } // txtCamelSingular.Text

        string DefaultIconMenu { get; set; }

        string ClassPath { get; }

        string ClassesPath { get; }

        string GetSpecificType();

        string[] LoadedClass { get; }

        List<TripleValue<string, string, string, string>> Fields { get; }

        List<ComboParameter> ComboParameters { get; }

        List<IItemToReplace> ItemToReplaces { get; }

        List<TripleValue<string, string, string, string>> GetFieldListFromEntity(String EntityNameSingular);

        string GetItemToReplace(string key);

        string GetItemToReplace(int id);

        void AddComboParameter(ComboParameter comboParameter);

        bool ExistInFielList(string field);

        bool ExistInRelatedFielList(string field, string relatedEnitity);
    }
}
