using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class ItemFileToGenerate
    {
        public ItemFileToGenerate(
            int Id,
            string Name,
            string Path,
            string TemplateName,
            string TemplateDirectory,
            List<ItemToReplace> ItemToReplaces,
            string ItemFieldTypePlaceHolder,
            List<ItemFieldTypeTemplate> ItemFieldTypeTemplates = null,
            bool IsFromOriginalFile = false
            )
        {
            this.Id = Id;
            this.Name = Name;
            this.Path = Path;
            this.TemplateName = TemplateName;
            this.TemplateDirectory = TemplateDirectory;
            this.ItemFieldTypePlaceHolder = ItemFieldTypePlaceHolder;
            this.ItemToReplaces = ItemToReplaces;
            this.ItemFieldTypeTemplates = ItemFieldTypeTemplates;
            this.IsFromOriginalFile = IsFromOriginalFile;
            ReadTemplate();
            ReplaceAllKeysWithRealValues();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string TemplateName { get; set; }
        public string TemplateMarkup { get; set; }
        public bool IsFromOriginalFile { get; set; }
        public string TemplateDirectory { get; set; }
        public string ItemFieldTypePlaceHolder { get; set; }
        public List<ItemToReplace> ItemToReplaces { get; set; }
        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }

        private void ReadTemplate()
        {
            try
            {
                if (!string.IsNullOrEmpty(TemplateDirectory) && !string.IsNullOrEmpty(TemplateName))
                {
                    TemplateMarkup = System.IO.File.ReadAllText(TemplateDirectory + TemplateName);
                }
            }
            catch (Exception err)
            { }
        }

        private void ReplaceAllKeysWithRealValues()
        {
            foreach (var item in ItemToReplaces)
            {
                TemplateMarkup = TemplateMarkup.Replace(item.Key, item.Value);
            }
            TemplateMarkup += "\n";
        }

    }
}
