﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class ClassInfoDataBase : IClassInfoData
    {
        public ClassInfoDataBase
        (
            string classesPath,
            string className,
            List<IItemToReplace> itemToReplaces,
            List<ComboParameter> comboParameters = null
        )
        {
            this.ItemToReplaces = itemToReplaces;
            this.ComboParameters = comboParameters;
            this.ClassPath = classesPath + className;
            this.ClassesPath = classesPath;
            if (className.Length > 3)
            {
                LoadedClass = System.IO.File.ReadAllLines(this.ClassPath);
                this.Fields = this.GetFieldListFromEntity(this.LoadedClass);
            }
            else
            {
                LoadedClass = null;
                this.Fields = null;
            }
        }

        public virtual List<TripleValue<string, string, string, string>> GetFieldListFromEntity(String EntityNameSingular)
        {
            try
            {
                //esto es usado solo para tener el nombre de la entidad en sus diferentes case
                ComboParameter cb = new ComboParameter(EntityNameSingular, "", "");
                var ClassPath = this.ClassesPath + cb.EntityPlural + ".cs";
                var loadedClass = System.IO.File.ReadAllLines(ClassPath);
                return this.GetFieldListFromEntity(loadedClass);
            }
            catch (Exception err) { }
            return new List<TripleValue<string, string, string, string>>();
        }


        public string XXXEntityPluralXXX { get => GetItemToReplace("XXXEntityPluralXXX"); } // txtCapitalPlural.Text
        public string XXXEntityLowerPluralXXX { get => GetItemToReplace("XXXEntityLowerPluralXXX"); } // txtCamelPlural.Text
        public string XXXEntitySingularXXX { get => GetItemToReplace("XXXEntitySingularXXX"); } //  txtCapitalSingular.Text);
        public string XXXEntityLowerSingularXXX { get => GetItemToReplace("XXXEntityLowerSingularXXX"); } // txtCamelSingular.Text

        public string DefaultIconMenu { get; set; }

        public string ClassPath { get; protected set; }

        public string ClassesPath { get; protected set; }

        public string[] LoadedClass { get; protected set; }

        public List<TripleValue<string, string, string, string>> Fields { get; protected set; }

        public List<ComboParameter> ComboParameters { get; protected set; }

        public List<IItemToReplace> ItemToReplaces { get; protected set; }

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

        protected virtual List<TripleValue<string, string, string, string>> GetFieldListFromEntity(string[] loadedClass)
        {
            var fieldList = new List<TripleValue<string, string, string, string>>();
            try
            {
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

        protected string GetTypeString(string Line)
        {
            string currentType = "";

            var index = Line.IndexOf("public");
            var indexType = Line.IndexOf(" ", index + 1);
            var indexProperty = Line.IndexOf(" ", indexType + 1);
            currentType = Line.Substring(indexType + 1, indexProperty - indexType - 1);
            return currentType;
        }

        protected string GetPropertyString(string Line)
        {
            string property = "";

            var index = Line.IndexOf("public");
            var indexType = Line.IndexOf(" ", index + 1);
            var indexProperty = Line.IndexOf(" ", indexType + 1);
            var indexPropertyEnd = Line.IndexOf(" ", indexProperty + 1);
            property = Line.Substring(indexProperty + 1, indexPropertyEnd - indexProperty - 1).Replace('}', ' ').Replace('{', ' ').TrimEnd();
            return property;
        }

        protected string GetMaxLengString(string Line)
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

        protected string GetMaxLengIntForString(string Line)
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

        public virtual string GetSpecificType() => "int";
    }
}