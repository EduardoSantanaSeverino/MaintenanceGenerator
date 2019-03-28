using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class ClassInfoDataBase : IClassInfoData
    {
        public string XXXEntityPluralXXX { get => GetItemToReplace("XXXEntityPluralXXX"); } // txtCapitalPlural.Text
        public string XXXEntityLowerPluralXXX { get => GetItemToReplace("XXXEntityLowerPluralXXX"); } // txtCamelPlural.Text
        public string XXXEntitySingularXXX { get => GetItemToReplace("XXXEntitySingularXXX"); } //  txtCapitalSingular.Text);
        public string XXXEntityLowerSingularXXX { get => GetItemToReplace("XXXEntityLowerSingularXXX"); } // txtCamelSingular.Text

        public string DefaultIconMenu { get; set; }

        public string ClassPath { get; protected set; }

        public string ClassesPath { get; protected set; }

        public string SpecificType { get; protected set; }

        public string[] LoadedClass { get; protected set; }

        public List<TripleValue<string, string, string, string>> Fields { get; protected set; }

        public List<ComboParameter> ComboParameters { get; protected set; }

        public List<ItemToReplace> ItemToReplaces { get; protected set; }

        public abstract List<TripleValue<string, string, string, string>> GetFieldListFromEntity(String EntityNameSingular);

        public string GetItemToReplace(string key)
        {
            return this.ItemToReplaces?.FirstOrDefault(p => p.Key == key)?.Value;
        }

        public string GetItemToReplace(int id)
        {
            return this.ItemToReplaces?.FirstOrDefault(p => p.Id == id)?.Value;
        }

        public void AddComboParameter(ComboParameter comboParameter)
        {
            if (this.ComboParameters == null)
            {
                this.ComboParameters = new List<ComboParameter>();
            }
            this.ComboParameters.Add(comboParameter);
        }

        public bool ExistInFielList(string field)
        {
            return Fields.Any(x => x.Value == field);
        }

        public bool ExistInRelatedFielList(string field, string relatedEnitity)
        {
            return this.GetFieldListFromEntity(relatedEnitity).Any(x => x.Value == field);
        }
    }
}
