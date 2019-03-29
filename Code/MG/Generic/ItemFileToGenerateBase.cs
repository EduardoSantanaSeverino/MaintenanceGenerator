﻿using System;
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
                markup = markup.Replace(item.Name, ProcessField(item) + "\n" + item.Name);
            }
            return markup;
        }

        protected string ProcessField(ItemFieldTypeTemplate itemField)
        {
            string[] array = itemField.TemplateMarkup.Split('|');
            bool isMultiType = (array.Length > 1);

            var l = new List<string>();
            foreach (var item in this.ClassInfoData.Fields)
            {
                string n = "";

                if (isMultiType)
                {
                    bool isFound = false;   
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == item.Key)
                        {
                            isFound = true;
                            n = array[i + 1];
                        }
                    }
                    if (!isFound)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] == "default")
                            {
                                n = array[i + 1];
                            }
                        }
                    }
                }
                else
                {
                    n = itemField.TemplateMarkup;
                }

                if (!string.IsNullOrEmpty(n))
                {
                    n = n.Replace("XXXFieldNameXXX", item.Value);
                    n = n.Replace("XXXFieldTypeXXX", item.Key);
                    n = n.Replace("XXXFieldValueAltXXX", item.ValueAlt);
                    n = n.Replace("XXXFieldValueAppenedXXX", item.ValueAppened);

                    l.Add(n);
                }

            }
            return string.Join("\n", l.ToArray());
        }
    }
}
