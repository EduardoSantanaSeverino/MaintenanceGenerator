using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class CrudGenerator : CrudGeneratorBase, ICrudGenerator
    {
        public CrudGenerator(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces)
        {
            Initialize(Configuration, ItemToReplaces);

            this.Version = Configuration.GetConfig("Version");
            this.TemplateDirectory = Configuration.GetConfig("TemplateDirectory");
            this.ProjectName = Configuration.GetConfig("ProjectName");

        }

        public override void SetItemToReplace(List<IItemToReplace> itemToReplaces)
        {
            Initialize(this.Configuration, itemToReplaces);
        }

        public override void AddComboParameter(ComboParameter comboParameter)
        {
            this.ClassInfoData.AddComboParameter(comboParameter);
            LoadItemFileToCreate();
        }

        public override void btnGenerate_Click(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces)
        {
            Initialize(Configuration, ItemToReplaces);
        }

        private void Initialize(IConfiguration Configuration, List<IItemToReplace> ItemToReplaces)
        {
            string entity = ItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntityPluralXXX")?.Value;
            this.ClassInfoData = new ClassInfoData(Configuration.GetConfig("ClassesPath"), entity + ".cs", ItemToReplaces);
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
            ItemFileToGenerates = new List<IItemFileToGenerate>()
            {
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IndexCsHtmlTemplate,
                    Name: "IndexCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\index.cshtml",
                    TemplateName: "indexCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbIndexCshtmlGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateModalCsHtmlTemplate,
                    Name: "CreateModalCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.cshtml",
                    TemplateName: "createModalCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbCreateCsHtmlGenerator",
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
                    ControlName: "rtbUpdateCsHtmlGenerator",
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
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbIndexJsGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateJSTemplate,
                    Name: "CreateJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.js",
                    TemplateName: "createModalJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbCreateJsGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateJSTemplate,
                    Name: "UpdateJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\editModal.js",
                    TemplateName: "editModalJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbUpdateJsGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.DtoTemplate,
                    Name: "DtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + ClassInfoData.XXXEntityPluralXXX + "Dto.cs",
                    TemplateName: "Dto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbEntityDtoGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateDtoTemplate,
                    Name: "CreateDtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + ClassInfoData.XXXEntityPluralXXX + "CreateDto.cs",
                    TemplateName: "CreateDto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbEntityCreateDtoGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateDtoTemplate,
                    Name: "UpdateDtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + ClassInfoData.XXXEntityPluralXXX + "UpdateDto.cs",
                    TemplateName: "UpdateDto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbEntityUpdateDtoGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IAppServiceTemplate,
                    Name: "IAppServiceTemplate",
                    Path: Configuration.GetConfig("PathDirectoryAppService") + @"\I" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "IAppService.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbIAppSericeGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AppServiceTemplate,
                    Name: "AppServiceTemplate",
                    Path: Configuration.GetConfig("PathDirectoryAppService") + @"\" + ClassInfoData.XXXEntitySingularXXX + "AppService.cs",
                    TemplateName: "AppService.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbAppSericeGenerator"
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AuthorizationProviderTemplate,
                    Name: "AuthorizationProviderTemplate",
                    Path: this.Configuration.GetConfig("AuthorizationProviderFile"),
                    TemplateName: "AuthorizationProvider.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbAutorizationProviderGenerator",
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate("")
                        {
                            Name = "AuthorizationProviderFile",
                            TemplateName = this.Configuration.GetConfig("AuthorizationProviderFile")
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.PermissionNameTemplate,
                    Name: "PermissionNameTemplate",
                    Path: this.Configuration.GetConfig("PermissionNamesFile"),
                    TemplateName: "PermissionName.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbPermissionNameGenerator",
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate("")
                        {
                            Name = "PermissionNamesFile",
                            TemplateName = this.Configuration.GetConfig("PermissionNamesFile")
                        },
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "AuthorizationProviderTemplate",
                            TemplateName = "AuthorizationProvider.tpt"
                        },

                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AppJsMenuTemplate,
                    Name: "AppJsMenuTemplate",
                    Path: this.Configuration.GetConfig("AppJsFile"),
                    TemplateName: "AppJsMenu.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbAppJsGenerator",
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate("")
                        {
                            Name = "AppJsFile",
                            TemplateName = this.Configuration.GetConfig("AppJsFile")
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.NavigationProviderTemplate,
                    Name: "NavigationProviderTemplate",
                    Path: this.Configuration.GetConfig("NavigationProviderFile"),
                    TemplateName: "NavigationProvider.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbNavigationProviderGenerator",
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate(TemplateDirectory)
                        {
                            Name = "AuthorizationProviderTemplate",
                            TemplateName = "AuthorizationProvider.tpt"
                        },
                        new ItemFieldTypeTemplate("")
                        {
                            Name = "NavigationProviderFile",
                            TemplateName = this.Configuration.GetConfig("NavigationProviderFile")
                        }
                    }
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.MenuSideBarNavTemplate,
                    Name: "MenuSideBarNavTemplate",
                    Path: this.Configuration.GetConfig("NavBarJSFile"),
                    TemplateName: "MenuSideBarNav.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    ControlName: "rtbMenuNavBarGenerator",
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>
                    {
                        new ItemFieldTypeTemplate("")
                        {
                            Name = "NavBarJSFile",
                            TemplateName = this.Configuration.GetConfig("NavBarJSFile")
                        }
                    }
                )
            };
        }

       
    }
}
