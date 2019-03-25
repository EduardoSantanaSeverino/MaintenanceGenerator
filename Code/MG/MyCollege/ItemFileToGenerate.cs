using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class ItemFileToGenerate
    {
        public ItemFileToGenerate
        (
            int Id,
            string Name,
            string Path,
            string TemplateName,
            string TemplateDirectory,
            List<ItemToReplace> ItemToReplaces,
            ClassInfoData ClassInfoData,
            List<ComboParameter> ComboParameters = null,
            List<ItemFieldTypeTemplate> ItemFieldTypeTemplates = null,
            bool IsFromOriginalFile = false
        )
        {
            this.Id = Id;
            this.Name = Name;
            this.Path = Path;
            this.TemplateName = TemplateName;
            this.TemplateDirectory = TemplateDirectory;
            this.ItemToReplaces = ItemToReplaces;
            this.ComboParameters = ComboParameters;
            this.ItemFieldTypeTemplates = ItemFieldTypeTemplates;
            this.IsFromOriginalFile = IsFromOriginalFile;
            this.ClassInfoData = ClassInfoData;
            this.TemplateMarkup = ReadTemplate();
            ProcessFile();
            this.TemplateMarkup = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string TemplateName { get; set; }
        public string TemplateMarkup { get; set; }
        public bool IsFromOriginalFile { get; set; }
        public string TemplateDirectory { get; set; }
        public List<ComboParameter> ComboParameters { get; set; }
        public ClassInfoData ClassInfoData { get; set; }
        public List<ItemToReplace> ItemToReplaces { get; set; }
        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }

        public string GetFieldTypeTemplate(string name)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Name == name)?.TemplateMarkup;
        }

        public string GetFieldTypeTemplate(int id)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Id == id)?.TemplateMarkup;
        }

        private string ReadTemplate()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.TemplateDirectory) && !string.IsNullOrEmpty(this.TemplateName))
                {
                    return System.IO.File.ReadAllText(this.TemplateDirectory + this.TemplateName);
                }
            }
            catch (Exception err)
            { }
            return "";
        }

        private string ReplaceAllKeysWithRealValues(string markup)
        {
          
            foreach (var item in ItemToReplaces)
            {
                markup = markup.Replace(item.Key, item.Value);
            }
            
            markup += "\n";
            return markup;
        }

        // this moment i run out of ideas to put this here
        private void ProcessFile()
        {
            if (this.Id == (int)FileStackId.CreateModalCsHtmlTemplate ||
                this.Id == (int)FileStackId.UpdateCsHtmlTemplate )
            {
                var strinWithFields = GenerateFielListForCreateCsHtml(ClassInfoData.Fields);
                this.TemplateMarkup = this.TemplateMarkup.Replace(@"//XXXFieldsHtmlXXX".ToString(), strinWithFields); 
            }
        }




        private string XXXInsertPermissionNamesXXX = "//XXXInsertPermissionNamesXXX";
        private string XXXInsertNavitationProviderXXX = "//XXXInsertNavitationProviderXXX";
        private string XXXInsertAuthorizationProviderXXX = "//XXXInsertAuthorizationProviderXXX";
        private string XXXInsertAppJsMenuXXX = "//XXXInsertAppJsMenuXXX";
        private string XXXFieldKeyXXX = "XXXFieldKeyXXX";

        private string XXXEntityPluralXXX = "XXXEntityPluralXXX";
        private string XXXEntitySingularXXX = "XXXEntitySingularXXX";
        private string XXXEntityLowerSingularXXX = "XXXEntityLowerSingularXXX";
        private string XXXEntityLowerPluralXXX = "XXXEntityLowerPluralXXX";
        private string XXXInsertMenuItemXXX = "//XXXInsertMenuItemXXX";

        private string XXXServicesUsedDeclarationXXX = "XXXServicesUsedDeclarationXXX";
        private string XXXServicesUsedSettingXXX = "XXXServicesUsedSettingXXX";

        private string XXXFieldNameCamelXXX = "XXXFieldNameCamelXXX";
        private string XXXFieldNameCapitalXXX = "XXXFieldNameCapitalXXX";
        private string XXXFieldNameCapitalPluralXXX = "XXXFieldNameCapitalPluralXXX";
        private string XXXFieldNameCamelSingularXXX = "XXXFieldNameCamelSingularXXX";

        private string XXXrequiredXXX = "XXXrequiredXXX";
        private string XXXProjectNameXXX = "XXXProjectNameXXX";

        private static string XXXRepositorySettingListXXX = "XXXRepositorySettingListXXX";
        private static string XXXRepositoryDeclarationListXXX = "XXXRepositoryDeclarationListXXX";

        private string XXXFirstFieldNameXXX = "XXXFirstFieldNameXXX";

        private string XXXFieldNameCapitalSingularXXX = "XXXFieldNameCapitalSingularXXX";
        private string XXXFieldNameCamelPluralXXX = "XXXFieldNameCamelPluralXXX";

        private string GenerateFielListForCreateCsHtml(List<TripleValue<string, string, string, string>> fielList)
        {
            var fieldListForIndexCsHtml = new List<string>();

            var FieldStringTemplate = GetFieldTypeTemplate("FieldStringTemplate"); // UsingTemplates.CsHtmlCreator.FieldString;
            FieldStringTemplate = ReplaceAllKeysWithRealValues(FieldStringTemplate);
            
            var FieldDateTimeTemplate = GetFieldTypeTemplate("FieldDateTimeTemplate"); //UsingTemplates.CsHtmlCreator.FieldDatetime;
            FieldDateTimeTemplate = ReplaceAllKeysWithRealValues(FieldDateTimeTemplate);

            var FieldBooleanTemplate = GetFieldTypeTemplate("FieldBooleanTemplate"); //UsingTemplates.CsHtmlCreator.FieldBoolean;
            FieldBooleanTemplate = ReplaceAllKeysWithRealValues(FieldBooleanTemplate);

            var FieldNumberTemplate = GetFieldTypeTemplate("FieldNumberTemplate"); //UsingTemplates.CsHtmlCreator.FieldNumber;
            FieldNumberTemplate = ReplaceAllKeysWithRealValues(FieldNumberTemplate);

            var FieldRelatedTemplate = GetFieldTypeTemplate("FieldComboTemplate");
            FieldRelatedTemplate = ReplaceAllKeysWithRealValues(FieldRelatedTemplate);

            foreach (var item in fielList)
            {
                //Commented for now.
                //AddLocalization(txtCapitalSingular.Text + item.Value);
                string isRequired = "required";
                string nameCamel = item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1);
                string newField = "";

                //Si el campo indicado esta como un combo ( en la lista de combos), se crea el combo y en caso contrario otro tipo de campo.
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    string fieldForAngular = item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1);
                    newField = FieldRelatedTemplate.Replace(XXXFieldKeyXXX, fieldForAngular);
                    newField = newField.Replace(XXXFieldNameCamelXXX, comboParameter.FieldNameValue.Substring(0, 1).ToLower() + comboParameter.FieldNameValue.Substring(1));
                    newField = newField.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);
                    newField = newField.Replace(XXXFieldNameCamelPluralXXX, comboParameter.EntityCamelPlural);
                    newField = newField.Replace(XXXFieldNameCapitalXXX, comboParameter.EntitySingular);
                    newField = newField.Replace(XXXFieldNameCamelSingularXXX, comboParameter.EntityCamelSingular);
                    newField = newField.Replace(XXXFieldNameCapitalSingularXXX, comboParameter.EntitySingular);
                }
                else
                {
                    if (item.Key == "String" || item.Key == "string")
                    {
                        newField = FieldStringTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                        newField = newField.Replace("XXXMaxLengthXXX", string.IsNullOrEmpty(item.ValueAlt) ? "" : "maxlength=\"" + item.ValueAppened + "\" \n");
                        newField = newField.Replace("XXXMaxLengthmdXXX", string.IsNullOrEmpty(item.ValueAlt) ? "" : "md-maxlength=\"" + item.ValueAppened + "\" \n");
                    }

                    if (item.Key == "int" || item.Key == "long" || item.Key == "decimal" || item.Key == "Decimal" || item.Key == "double"
                        || item.Key == "Double" || item.Key == "Integer" || item.Key == "Int64" || item.Key == "Int32" || item.Key == "Int16")
                    {
                        newField = FieldNumberTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                    }

                    if (item.Key == "bool" || item.Key == "Bool" || item.Key == "Boolean" || item.Key == "boolean")
                    {
                        newField = FieldBooleanTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                    }

                    if (item.Key == "datetime" || item.Key == "DateTime" || item.Key == "Date" || item.Key == "date")
                    {
                        newField = FieldDateTimeTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                    }

                    newField = newField.Replace(XXXFieldNameCapitalXXX, item.Value);
                    newField = newField.Replace(XXXrequiredXXX, isRequired);
                }
                fieldListForIndexCsHtml.Add(newField);
            }

            return string.Join("", fieldListForIndexCsHtml.ToArray());
        }

        private ComboParameter GetComboParameter(string FieldNameValue)
        {
            return this.ComboParameters?.FirstOrDefault(p=>p.FieldNameValue == FieldNameValue);
        }

    }
}
