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

            Configuration.AddConfig(new ItemConfig
            {
                Name = "ViewDirectory",
                Value = Configuration.GetConfig("ViewsDirectory") + ItemToReplaces.FirstOrDefault(p => p.Name == "XXXEntityLowerPluralXXX")
            });

            Configuration.AddConfig(new ItemConfig
            {
                Name = "ClassPath",
                Value = Configuration.GetConfig("ClassesPath") + ItemToReplaces.FirstOrDefault(p=>p.Name == "XXXEntityPluralXXX") + ".cs"
            });

            Configuration.AddConfig(new ItemConfig
            {
                Name = "DtoPath",
                Value = Configuration.GetConfig("DtosPath") + ItemToReplaces.FirstOrDefault(p => p.Name == "XXXEntityPluralXXX") + @"\Dto\"
            });

            this.Configuration = Configuration;

            // string PathDirectoryAppService = pathDirectoryApp + txtCapitalPlural.Text;
            this.ClassInfoData = new ClassInfoData(Configuration.GetConfig("ClassPath"), ItemToReplaces);
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
                    ItemToReplaces: this.ItemToReplaces,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateModalCsHtmlTemplate,
                    Name: "CreateModalCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.cshtml",
                    TemplateName: "createModalCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemToReplaces: this.ItemToReplaces,
                    ClassInfoData: this.ClassInfoData,
                    ComboParameters: this.ComboParameters,
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
                    ItemToReplaces: this.ItemToReplaces,
                    ClassInfoData: this.ClassInfoData,
                    ComboParameters: this.ComboParameters,
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
                    ItemToReplaces: this.ItemToReplaces,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.CreateJSTemplate,
                    Name: "CreateJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.js",
                    TemplateName: "createModalJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemToReplaces: this.ItemToReplaces,
                    ClassInfoData: this.ClassInfoData
                ),
                 new ItemFileToGenerate
                (
                    Id: (int)FileStackId.UpdateJSTemplate,
                    Name: "UpdateJSTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\editModal.js",
                    TemplateName: "editModalJS.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemToReplaces: this.ItemToReplaces,
                    ClassInfoData: this.ClassInfoData
                ),
                new ItemFileToGenerate
                (
                    Id: (int)FileStackId.DtoTemplate,
                    Name: "DtoTemplate",
                    Path: Configuration.GetConfig("DtoPath") + GetItemToReplaces("XXXEntityPluralXXX") + "Dto.cs", 
                    TemplateName: "Dto.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemToReplaces: this.ItemToReplaces,
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
