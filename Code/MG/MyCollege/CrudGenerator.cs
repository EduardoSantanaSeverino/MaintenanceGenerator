using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class CrudGenerator
    {
        public ClassInfoData ClassInfoData { get; set; }
        public Configuration Configuration { get; set; }
        public string Version { get { return Configuration.Version; } }
        public string TemplateDirectory { get { return Configuration.TemplateDirectory; } }
        public string ProjectName { get { return Configuration.ProjectName; } }

        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }
        public List<ItemFileToGenerate> ItemFileToGenerates { get; set; }

        public CrudGenerator(Configuration Configuration, List<ItemToReplace> ItemToReplaces)
        {
            string entity = ItemToReplaces.FirstOrDefault(p => p.Name == "XXXEntityPluralXXX").Value;
            this.ClassInfoData = new ClassInfoData(Configuration.GetConfig("ClassesPath") + entity + ".cs", ItemToReplaces);

            Configuration.AddConfig(new List<ItemConfig> {
                new ItemConfig
                {
                    Name = "ClassPath",
                    Value = Configuration.GetConfig("ClassesPath") + this.ClassInfoData.XXXEntityPluralXXX + ".cs"
                },
                new ItemConfig
                {
                    CreateDirectory = true,
                    Name = "ViewDirectory",
                    Value = Configuration.GetConfig("ViewsDirectory") + this.ClassInfoData.XXXEntityLowerPluralXXX
                },
                new ItemConfig
                {
                    CreateDirectory = true,
                    Name = "DtoPath",
                    Value = Configuration.GetConfig("DtosPath") + this.ClassInfoData.XXXEntityPluralXXX + @"\Dto\"
                },
                new ItemConfig
                {
                    CreateDirectory = true,
                    Name = "PathDirectoryAppService",
                    Value = Configuration.GetConfig("PathDirectoryApp") + this.ClassInfoData.XXXEntityPluralXXX
                }
            });

            this.Configuration = Configuration;

            LoadItemFileToCreate();
        }

        private void LoadItemFileToCreate()
        {
            ItemFileToGenerates = new List<ItemFileToGenerate>()
            {
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IndexCsHtmlTemplate,
                    Name: "IndexCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\index.cshtml",
                    TemplateName: "indexCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateModalCsHtmlTemplate,
                    Name: "CreateModalCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.cshtml",
                    TemplateName: "createModalCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldNumberTemplate",
                            TemplateName = "FieldNumberTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldStringTemplate",
                            TemplateName = "FieldStringTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldDateTimeTemplate",
                            TemplateName = "FieldDateTimeTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldBooleanTemplate",
                            TemplateName = "FieldBooleanTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldComboTemplate",
                            TemplateName = "FieldComboTemplate.tpt"
                        },
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateCsHtmlTemplate,
                    Name: "UpdateCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\editModal.cshtml",
                    TemplateName: "editModalCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldNumberTemplate",
                            TemplateName = "FieldNumberTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldStringTemplate",
                            TemplateName = "FieldStringTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldDateTimeTemplate",
                            TemplateName = "FieldDateTimeTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldBooleanTemplate",
                            TemplateName = "FieldBooleanTemplate.tpt"
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "FieldComboTemplate",
                            TemplateName = "FieldComboTemplate.tpt"
                        },
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IndexJSTemplate,
                    Name: "IndexJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\index.js",
                    TemplateName: "indexJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateJSTemplate,
                    Name: "CreateJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.js",
                    TemplateName: "createModalJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateJSTemplate,
                    Name: "UpdateJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\editModal.js",
                    TemplateName: "editModalJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.DtoTemplate,
                    Name: "DtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + ClassInfoData.XXXEntityPluralXXX + "Dto.cs", 
                    TemplateName: "Dto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateDtoTemplate,
                    Name: "CreateDtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + ClassInfoData.XXXEntityPluralXXX + "CreateDto.cs",
                    TemplateName: "CreateDto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateDtoTemplate,
                    Name: "UpdateDtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + ClassInfoData.XXXEntityPluralXXX + "UpdateDto.cs",
                    TemplateName: "UpdateDto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IAppServiceTemplate,
                    Name: "IAppServiceTemplate",
                    Path: Configuration.GetConfig("PathDirectoryAppService") + @"\I" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "IAppService.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AppServiceTemplate,
                    Name: "AppServiceTemplate",
                    Path: Configuration.GetConfig("PathDirectoryAppService") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "AppService.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AuthorizationProviderTemplate,
                    Name: "AuthorizationProviderTemplate",
                    Path: Configuration.GetConfig("") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "AuthorizationProvider.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.PermissionNameTemplate,
                    Name: "PermissionNameTemplate",
                    Path: Configuration.GetConfig("") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "PermissionName.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AppJsMenuTemplate,
                    Name: "AppJsMenuTemplate",
                    Path: Configuration.GetConfig("") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "AppJsMenu.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.NavigationProviderTemplate,
                    Name: "NavigationProviderTemplate",
                    Path: Configuration.GetConfig("") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "NavigationProvider.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.MenuSideBarNavTemplate,
                    Name: "MenuSideBarNavTemplate",
                    Path: Configuration.GetConfig("") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "MenuSideBarNav.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),

        };

        }

       

        public void AddComboParameter(ComboParameter comboParameter)
        {
            this.ClassInfoData.AddComboParameter(comboParameter);
            LoadItemFileToCreate();
        }

        public void txtEntityNameSingular_TextChanged()
        {
            throw new NotImplementedException();
        }

        public void btnGenerate_Click()
        {
            throw new NotImplementedException();
        }

        public void btnGenerate_Click(object p)
        {
            throw new NotImplementedException();
        }

        public void btnSaveOnDisk_Click()
        {
            throw new NotImplementedException();
        }
        
    }
}
