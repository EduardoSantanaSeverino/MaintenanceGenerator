namespace MG.Application.Generic
{
    public interface IItemFileToGenerate
    {
         int Id { get; set; }
         string Name { get; set; }
         string Path { get; set; }
         string TemplateName { get; set; }
         string TemplateMarkup { get; set; }
         string TemplateDirectory { get; set; }
         IClassInfoData ClassInfoData { get; set; }
         string ControlName { get; set; }
         List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }
    }
}
