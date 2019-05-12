using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.SocialUplift
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
            List<ItemFieldTypeTemplate> ItemFieldTypeTemplates = null,
            FileTypes FileType = FileTypes.Others
        )
        : base
        (
            Id,
            Enum.GetName(typeof(FileStackId), Id),
            Path,
            TemplateName,
            TemplateDirectory,
            ClassInfoData,
            ItemFieldTypeTemplates,
            FileType.ToString()
        )
        {
        }
    }
}
