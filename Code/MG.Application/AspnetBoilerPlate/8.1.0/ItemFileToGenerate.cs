using MG.Application.Generic;

namespace MG.Application.AspnetBoilerPlate._8._1._0
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
            FileType.ToString(),
            "AspnetBoilerPlate/8.1.0/Templates/"
        )
        {
        }
    }
}
