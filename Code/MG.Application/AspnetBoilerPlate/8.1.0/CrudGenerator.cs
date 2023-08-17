using MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;
using MG.Application.Generic;

namespace MG.Application.AspnetBoilerPlate._8._1._0
{
    public class CrudGenerator : CrudGeneratorBase, ICrudGenerator
    {
        public CrudGenerator(IConfiguration configuration) : base(configuration, new ItemFilePlaceHolderList())
        {
        }

        protected override void LoadItemFileToCreate()
        {
            string entitySingular = this.ClassInfoData.XXXEntitySingularXXX;
            string entityPlural = this.ClassInfoData.XXXEntityPluralXXX;
            string entityLowerPlural = this.ClassInfoData.XXXEntityLowerPluralXXX;
            string entityLowerSingular = this.ClassInfoData.XXXEntityLowerSingularXXX;
            
            ItemFileToGenerates = new List<IItemFileToGenerate>()
            {
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.app_module_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + "app.module.ts",
                    TemplateName: "app.module.ts",
                    TemplateDirectory: Configuration.GetConfig("AngularAppDirectory"),
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.app_routing_module_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + "app-routing.module.ts",
                    TemplateName: "app-routing.module.ts",
                    TemplateDirectory: Configuration.GetConfig("AngularAppDirectory"),
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate // tenants
                (
                    Id: (int)FileStackId.component_html,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $@"\{entityLowerPlural}.component.html",
                    TemplateName: "component.html",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    FileType: FileTypes.List
                ),
                new ItemFileToGenerate // tenants
                (
                    Id: (int)FileStackId.component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $@"\{entityLowerPlural}.component.ts",
                    TemplateName: "component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate // tenants
                (
                    Id: (int)FileStackId.create_dialog_component_html,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $@"\create-{entityLowerSingular}\create-{entityLowerSingular}-dialog.component.html",
                    TemplateName: "create-dialog.component.html",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    FileType: FileTypes.Create
                ),
                new ItemFileToGenerate // tenants
                (
                    Id: (int)FileStackId.create_dialog_component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $@"\create-{entityLowerSingular}\create-{entityLowerSingular}-dialog.component.ts",
                    TemplateName: "create-dialog.component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate // tenants
                (
                    Id: (int)FileStackId.edit_dialog_component_html,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $@"\edit-{entityLowerSingular}\edit-{entityLowerSingular}-dialog.component.html",
                    TemplateName: "edit-dialog.component.html",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData,
                    FileType: FileTypes.Update
                ),
                new ItemFileToGenerate // tenants
                (
                    Id: (int)FileStackId.edit_dialog_component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $@"\edit-{entityLowerSingular}\edit-{entityLowerSingular}-dialog.component.ts",
                    TemplateName: "edit-dialog.component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.sidebar_menu_component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + $@"layout\sidebar-menu.component.ts",
                    TemplateName: "sidebar-menu.component.ts",
                    TemplateDirectory: Configuration.GetConfig("AngularAppDirectory") + $@"layout\",
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.service_proxy_module_ts,
                    Path: Configuration.GetConfig("AngularSharedDirectory") + $@"service-proxies\service-proxy.module.ts",
                    TemplateName: "service-proxy.module.ts",
                    TemplateDirectory: Configuration.GetConfig("AngularSharedDirectory") + $@"service-proxies\",
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AppService_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $@"{entityPlural}\{entitySingular}AppService.cs",
                    TemplateName: "AppService.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IAppService_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $@"{entityPlural}\I{entitySingular}AppService.cs",
                    TemplateName: "IAppService.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.PagedResultRequestDto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $@"{entityPlural}\Dto\Paged{entitySingular}ResultRequestDto.cs",
                    TemplateName: "PagedResultRequestDto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateDto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $@"{entityPlural}\Dto\Create{entitySingular}Dto.cs",
                    TemplateName: "CreateDto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.Dto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $@"{entityPlural}\Dto\{entitySingular}Dto.cs",
                    TemplateName: "Dto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateDto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $@"{entityPlural}\Dto\Update{entitySingular}Dto.cs",
                    TemplateName: "UpdateDto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.PermissionNames_cs,
                    Path: Configuration.GetConfig("AuthorizationDirectory") + $"PermissionNames.cs",
                    TemplateName: "PermissionNames.cs",
                    TemplateDirectory: Configuration.GetConfig("AuthorizationDirectory"),
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AuthorizationProvider_cs,
                    Path: Configuration.GetConfig("AuthorizationDirectory") + $"{this.ProjectName}AuthorizationProvider.cs",
                    TemplateName: $"{this.ProjectName}AuthorizationProvider.cs",
                    TemplateDirectory: Configuration.GetConfig("AuthorizationDirectory"),
                    ClassInfoData: this.ClassInfoData,
                    ItemFieldTypeTemplates: new List<ItemFieldTypeTemplate>()
                    {
                        new ItemFieldTypeTemplate
                        {
                            Name = "///AuthorizationProvider.cs.place1///",
                            TemplateName = "AuthorizationProvider.cs.place1.cs",
                            ForFields = false
                        }
                    }
                ),
            };
        }
       
    }
}
