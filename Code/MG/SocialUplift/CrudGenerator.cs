﻿using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.SocialUplift
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
                }
            });

            this.Configuration = Configuration;

            LoadItemFileToCreate();
            
        }


        protected override void LoadItemFileToCreate()
        {
            string entitySingular = Configuration.GetConfig("XXXEntitySingularXXX");
            string entityPlural = Configuration.GetConfig("XXXEntityPluralXXX");
            string entityLowerPlural = Configuration.GetConfig("XXXEntityLowerPluralXXX");
            string entityLowerSingular = Configuration.GetConfig("XXXEntityLowerSingularXXX");

            ItemFileToGenerates = new List<IItemFileToGenerate>()
            {
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.app_module_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + "app.module.ts",
                    TemplateName: "app.module.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.app_routing_module_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + "app-routing.module.ts",
                    TemplateName: "app-routing.module.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.component_html,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $"/{entityLowerPlural}.component.html",
                    TemplateName: "component.html",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $"/{entityLowerPlural}.component.ts",
                    TemplateName: "component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.create_dialog_component_html,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $"/create-{entityLowerSingular}-dialog.component.html",
                    TemplateName: "create-dialog-component.html",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.create_dialog_component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $"/create-{entityLowerSingular}-dialog.component.ts",
                    TemplateName: "create-dialog-component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.edit_dialog_component_html,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $"/edit-{entityLowerSingular}-dialog.component.html",
                    TemplateName: "edit-dialog-component.html",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.edit_dialog_component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + entityLowerPlural + $"/edit-{entityLowerSingular}-dialog.component.ts",
                    TemplateName: "edit-dialog-component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.sidebar_nav_component_ts,
                    Path: Configuration.GetConfig("AngularAppDirectory") + $"layout/sidebar-nav.component.ts",
                    TemplateName: "sidebar-nav.component.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.service_proxy_module_ts,
                    Path: Configuration.GetConfig("AngularSharedDirectory") + $"service-proxies/service-proxy.module.ts",
                    TemplateName: "service-proxy.module.ts",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AppService_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $"{entityPlural}/{entitySingular}AppService.cs",
                    TemplateName: "AppService.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.IAppService_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $"{entityPlural}/I{entitySingular}AppService.cs",
                    TemplateName: "IAppService.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateDto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $"{entityPlural}/Dto/{entitySingular}CreateDto.cs",
                    TemplateName: "CreateDto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.Dto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $"{entityPlural}/Dto/{entitySingular}Dto.cs",
                    TemplateName: "Dto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateDto_cs,
                    Path: Configuration.GetConfig("ApplicationDirectory") + $"{entityPlural}/Dto/{entitySingular}UpdateDto.cs",
                    TemplateName: "UpdateDto.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.PermissionNames_cs,
                    Path: Configuration.GetConfig("AuthorizationDirectory") + $"PermissionNames.cs",
                    TemplateName: "PermissionNames.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.AuthorizationProvider_cs,
                    Path: Configuration.GetConfig("AuthorizationDirectory") + $"{this.ProjectName}AuthorizationProvider.cs",
                    TemplateName: "AuthorizationProvider.cs",
                    TemplateDirectory: TemplateDirectory,
                    ClassInfoData: this.ClassInfoData
                ),
            };
        }
       
    }
}
