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
        : base
        (
            Id,
            Enum.GetName(typeof(FileStackId), Id),
            Path,
            TemplateName,
            TemplateDirectory,
            ClassInfoData,
            ItemFieldTypeTemplates
        )
        {
        }
    }
}
