using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.CentennialForm
{
    public class CrudGenerator : CrudGeneratorBase, ICrudGenerator
    {
        public CrudGenerator(IConfiguration Configuration)
        {
            Initialize(Configuration, Configuration.GetItemToReplaces());

            this.Version = Configuration.GetConfig("Version");
            this.TemplateDirectory = Configuration.GetConfig("TemplateDirectory");
            this.ProjectName = Configuration.GetConfig("ProjectName");
        }

        protected override void Initialize(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces)
        {
            string entitySingular = ItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntitySingularXXX")?.Value;
            string entityPlural = ItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntityPluralXXX")?.Value;

            this.ClassInfoData = new ClassInfoData(Configuration.GetConfig("ClassesPath"), entitySingular + ".cs", ItemToReplaces);
            Configuration.AddConfig(new List<ItemConfig> {
                new ItemConfig
                {
                    Name = "ClassPath",
                    Value = Configuration.GetConfig("ClassesPath") + this.ClassInfoData.XXXEntitySingularXXX + ".cs"
                },
                new ItemConfig
                {
                    Name = "SaveCrudFolder",
                    Value = $@"Crud{entityPlural}\",
                    CreateDirectory = true
                }
            });

            this.Configuration = Configuration;

            LoadItemFileToCreate();
            
        }

        protected override void LoadItemFileToCreate()
        {
            ItemFileToGenerates = new List<IItemFileToGenerate>()
            {
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IndexCs,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Index.cs",
                    TemplateName: "Index.cs.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IndexDesigner,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Index.Designer.cs",
                    TemplateName: "Index.Designer.cs.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsIndexDesigner1TplXXX",
                            TemplateName = "FieldsIndexDesigner1Tpl.tpl"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsIndexDesigner2TplXXX",
                            TemplateName = "FieldsIndexDesigner2Tpl.tpl"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsIndexDesigner3TplXXX",
                            TemplateName = "FieldsIndexDesigner3Tpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IndexResx,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Index.resx",
                    TemplateName: "Index.resx.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsIndexResx1TplXXX",
                            TemplateName = "FieldsIndexResx1Tpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.DetailsCs,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Details.cs",
                    TemplateName: "Details.cs.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsTplXXX",
                            TemplateName = "FieldsDetailsTpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.DetailsDesigner,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Details.Designer.cs",
                    TemplateName: "Details.Designer.cs.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsDesigner1TplXXX",
                            TemplateName = "FieldsDetailsDesigner1Tpl.tpl"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsDesigner2TplXXX",
                            TemplateName = "FieldsDetailsDesigner2Tpl.tpl"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsDesigner3TplXXX",
                            TemplateName = "FieldsDetailsDesigner3Tpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.DetailsResx,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Details.resx",
                    TemplateName: "Details.resx.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsIndexResx1TplXXX",
                            TemplateName = "FieldsIndexResx1Tpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.EditCs,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Edit.cs",
                    TemplateName: "Edit.cs.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsEdit1TplXXX",
                            TemplateName = "FieldsEdit1Tpl.tpl"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsEdit2TplXXX",
                            TemplateName = "FieldsEdit2Tpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.EditDesigner,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Edit.Designer.cs",
                    TemplateName: "Edit.Designer.cs.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsDesigner1TplXXX",
                            TemplateName = "FieldsDetailsDesigner1Tpl.tpl",
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsDesigner2TplXXX",
                            TemplateName = "FieldsDetailsDesigner2Tpl.tpl"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "//XXXFieldsDetailsDesigner3TplXXX",
                            TemplateName = "FieldsDetailsDesigner3Tpl.tpl"
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.EditResx,
                    Path: Configuration.GetConfig("SaveCrudFolder") + "Edit.resx",
                    TemplateName: "Edit.resx.tpl",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
            };
        }
       
    }
}
