using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
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
