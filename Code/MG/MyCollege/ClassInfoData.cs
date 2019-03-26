using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class ClassInfoData
    {
        private string _classPath { get; set; }
        private string _classesPath { get; set; }
        private string _specificType { get; set; }
        private List<TripleValue<string, string, string, string>> _fields { get; set; }
        private string[] _loadedClass { get; set; }

        public ClassInfoData
        (
            string classesPath,
            string className,
            List<ItemToReplace> itemToReplaces,
            List<ComboParameter> comboParameters = null
        )
        {
            this.ItemToReplaces = itemToReplaces;
            this.ComboParameters = comboParameters;
            this._classPath = classesPath + className;
            this._classesPath = classesPath;
            _loadedClass = System.IO.File.ReadAllLines(this._classPath);
            this._fields = this.GetFieldListFromEntity(this._loadedClass);
        }

        public string XXXEntityPluralXXX { get => GetItemToReplace("XXXEntityPluralXXX"); } // txtCapitalPlural.Text
        public string XXXEntityLowerPluralXXX { get => GetItemToReplace("XXXEntityLowerPluralXXX"); } // txtCamelPlural.Text
        public string XXXEntitySingularXXX { get => GetItemToReplace("XXXEntitySingularXXX"); } //  txtCapitalSingular.Text);
        public string XXXEntityLowerSingularXXX { get => GetItemToReplace("XXXEntityLowerSingularXXX"); } // txtCamelSingular.Text



        public string DefaultIconMenu { get; set; }

        public string ClassPath { get => this._classPath; }

        public string ClassesPath { get => this._classesPath; }

        public string SpecificType { get => this._specificType; }

        public string[] LoadedClass { get => this._loadedClass; }

        public List<TripleValue<string, string, string, string>> Fields { get => this._fields; }

        public List<ComboParameter> ComboParameters { get; set; }

        public List<ItemToReplace> ItemToReplaces { get; set; }

        private List<TripleValue<string, string, string, string>> GetFieldListFromEntity(string[] loadedClass)
        {
            var fieldList = new List<TripleValue<string, string, string, string>>();
            try
            {
                var classHeader = loadedClass.Where(x => x.Contains("Tenant<")).ToList().FirstOrDefault();
                if (classHeader != null)
                {
                    var index = classHeader.IndexOf("<");
                    var specificInitial = classHeader.Substring(index + 1, 1);
                    if (specificInitial != "i")
                        _specificType = "long";
                }

                var allowedtypes = new List<string>()
                {
                    "int",
                    "string",
                    "String",
                    "Integer",
                    "DateTime",
                    "Date",
                    "decimal",
                    "Decimal",
                    "float",
                    "double",
                    "Double",
                    "long",
                    "int32",
                    "int16",
                    "int64",
                    "bool",
                    "Boolean"
                };


                for (int i = 0; i < loadedClass.Length; i++)
                {
                    var lineX = loadedClass[i];
                    if (!lineX.Contains("public"))
                        continue;

                    if (lineX.Contains("class"))
                        continue;

                    if (lineX.Contains("("))
                        continue;


                    var type = GetTypeString(lineX);
                    var property = GetPropertyString(lineX);

                    if (!allowedtypes.Contains(type.Replace("?", "")))
                        continue;
                    var LineXAnterior = loadedClass[i - 1];
                    var MaxLenght = GetMaxLengString(LineXAnterior);
                    var MaxLenghtJustInt = GetMaxLengIntForString(LineXAnterior);

                    var field = new TripleValue<string, string, string, string>(type, property, MaxLenght, MaxLenghtJustInt);
                    fieldList.Add(field);
                }
            }
            catch (Exception err) { }
            return fieldList;
        }

        public List<TripleValue<string, string, string, string>> GetFieldListFromEntity(String EntityNameSingular)
        {
            try
            {
                //esto es usado solo para tener el nombre de la entidad en sus diferentes case
                ComboParameter cb = new ComboParameter(EntityNameSingular, "", "");
                var ClassPath = _classesPath + cb.EntityPlural + ".cs";
                var loadedClass = System.IO.File.ReadAllLines(ClassPath);
                return this.GetFieldListFromEntity(loadedClass);
            }
            catch (Exception err) { }
            return new List<TripleValue<string, string, string, string>>();
        }

        private string GetTypeString(string Line)
        {
            string currentType = "";

            var index = Line.IndexOf("public");
            var indexType = Line.IndexOf(" ", index + 1);
            var indexProperty = Line.IndexOf(" ", indexType + 1);
            currentType = Line.Substring(indexType + 1, indexProperty - indexType - 1);
            return currentType;
        }

        private string GetPropertyString(string Line)
        {
            string property = "";

            var index = Line.IndexOf("public");
            var indexType = Line.IndexOf(" ", index + 1);
            var indexProperty = Line.IndexOf(" ", indexType + 1);
            var indexPropertyEnd = Line.IndexOf(" ", indexProperty + 1);
            property = Line.Substring(indexProperty + 1, indexPropertyEnd - indexProperty - 1).Replace('}', ' ').Replace('{', ' ').TrimEnd();
            return property;
        }

        private string GetMaxLengString(string Line)
        {
            string maxlenghtX = string.Empty;
            string buscado = "Length(";

            var index = Line.IndexOf(buscado);
            if (index < 0)
                return maxlenghtX;
            var indexEndMaxLeng = Line.IndexOf(")", index);

            maxlenghtX = Line.Substring(index + buscado.Length, indexEndMaxLeng - (index + buscado.Length));
            return maxlenghtX;
        }

        private string GetMaxLengIntForString(string Line)
        {
            string maxlenghtX = string.Empty;
            string buscado = "Length(";

            var index = Line.IndexOf(buscado);
            if (index < 0)
                return maxlenghtX;
            var indexEndMaxLeng = Line.IndexOf(",", index);
            if (indexEndMaxLeng < 0)
                indexEndMaxLeng = Line.IndexOf(")", index);

            maxlenghtX = Line.Substring(index + buscado.Length, indexEndMaxLeng - (index + buscado.Length));
            return maxlenghtX;
        }

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

    }
}
