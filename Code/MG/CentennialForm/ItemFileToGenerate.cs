using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.CentennialForm
{
    public class ItemFileToGenerate : ItemFileToGenerateBase, IItemFileToGenerate
    {
        public ItemFileToGenerate
        (
            int Id,
            string Path,
            string TemplateName,
            string TemplateDirectory,
            IClassInfoData ClassInfoData,
            List<ItemFieldTypeTemplate> ItemFieldTypeTemplates = null
        )
        {
            this.Id = Id;
            this.Name = Enum.GetName(typeof(FileStackId), this.Id);
            this.ControlName = "rtb" + this.Name;
            this.Path = Path;
            this.TemplateName = TemplateName;
            this.TemplateDirectory = TemplateDirectory;
            this.ItemFieldTypeTemplates = ItemFieldTypeTemplates;
            this.ClassInfoData = ClassInfoData;
            this.TemplateMarkup = ReadTemplate();
            try
            {
                this.TemplateMarkup = ProcessGenericFields(this.TemplateMarkup);
            }
            catch (Exception ex)
            {
            }
            this.TemplateMarkup = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
        }
               
    }
}
