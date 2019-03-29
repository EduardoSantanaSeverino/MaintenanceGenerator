using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class ItemFileToGenerateBase : IItemFileToGenerate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string TemplateName { get; set; }
        public string TemplateMarkup { get; set; }
        public string TemplateDirectory { get; set; }
        public IClassInfoData ClassInfoData { get; set; }
        public string ControlName { get; set; }
        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }

        protected string GetFieldTypeTemplate(string name)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Name == name)?.TemplateMarkup;
        }

        protected string GetFieldTypeTemplate(int id)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Id == id)?.TemplateMarkup;
        }

        protected string ReadTemplate()
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

        protected string GetItemToReplaces(string key)
        {
            return ClassInfoData?.ItemToReplaces?.FirstOrDefault(p => p.Key == key)?.Value;
        }

        protected string ReplaceAllKeysWithRealValues(string markup)
        {
            if (!string.IsNullOrEmpty(markup))
            {
                foreach (var item in ClassInfoData?.ItemToReplaces)
                {
                    markup = markup.Replace(item.Key, item.Value);
                }

                markup += "\n";
            }

            return markup;
        }

        protected ComboParameter GetComboParameter(string FieldNameValue)
        {
            return this.ClassInfoData?.ComboParameters?.FirstOrDefault(p => p.FieldNameValue == FieldNameValue);
        }

        protected string ProcessGenericFields(string markup)
        {
            foreach (var item in this.ItemFieldTypeTemplates)
            {
                markup.Replace(item.Name, ProcessField(item));
            }
            return markup;
        }

        protected string ProcessField(ItemFieldTypeTemplate itemField)
        {
            foreach (var item in this.ClassInfoData.Fields)
            {
                itemField.TemplateMarkup.Replace("XXXFieldNameXXX", item.Key);
                itemField.TemplateMarkup.Replace("XXXFieldValueXXX", item.Value);
                itemField.TemplateMarkup.Replace("XXXFieldValueAltXXX", item.ValueAlt);
                itemField.TemplateMarkup.Replace("XXXFieldValueAppenedXXX", item.ValueAppened);
            }
            return itemField.TemplateMarkup;
        }
    }
}
