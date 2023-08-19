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
            string SourceTemplateDirectory,
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
            SourceTemplateDirectory
        )
        {
        }
    }
}
