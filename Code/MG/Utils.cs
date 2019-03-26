using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG
{
    class Utils
    {
        public static string SpecificType = "int";
        public static string Version = "MaintenanceGenerator Ver. 2.2";
        public static String TemplateDirectory = @"MGTemplates\";

        public static string ProjectName = "GEDUCON"; //This was de original project

        public static string SideBarFileName = "sidebar.js";

        public static List<TripleValue<String, String,String, String>> getFieldListFromEntity(String EntityNameSingular)
        {
            List<TripleValue<String, String, String, String>> fieldList = new List<TripleValue<String, String, String, String>>();
            try
            {
                //esto es usado solo para tener el nombre de la entidad en sus diferentes case
                ComboParameter cb = new ComboParameter(EntityNameSingular, "", "");
                var ClassPath = frmPrincipal.ClassesPath + cb.EntityPlural + ".cs";
                var loadedClass = System.IO.File.ReadAllLines(ClassPath);
                var classHeader = loadedClass.Where(x => x.Contains("Tenant<")).ToList().FirstOrDefault();
                if (classHeader != null)
                {
                    var index = classHeader.IndexOf("<");
                    var specificInitial = classHeader.Substring(index+1, 1);
                    if (specificInitial != "i")
                        SpecificType = "long";
                }
                
                List<string> allowedtypes = new List<string>() {
                    "int",
                    "string",
                    "String",
                    "Integer",
                    "DateTime",
                    "Date",
                    "decimal",
                    "Decimal",
                    "float",
                    "double",
                    "Double",
                    "long",
                    "int32",
                    "int16",
                    "int64",
                    "bool",
                    "Boolean" };


                for (int i = 0; i < loadedClass.Length; i++)
                {
                    var lineX = loadedClass[i];
                    if (!lineX.Contains("public"))
                        continue;

                    if (lineX.Contains("class"))
                        continue;

                    if (lineX.Contains("("))
                        continue;


                    var type = frmPrincipal.GetTypeString(lineX);
                    var property = frmPrincipal.GetPropertyString(lineX);

                    if (!allowedtypes.Contains(type.Replace("?","")))
                        continue;
                    var LineXAnterior = loadedClass[i - 1];
                    var MaxLenght = frmPrincipal.GetMaxLengString(LineXAnterior);
                    var MaxLenghtJustInt = frmPrincipal.GetMaxLengIntForString(LineXAnterior);

                    var field = new TripleValue<string, string, string, string>(type, property, MaxLenght, MaxLenghtJustInt);
                    fieldList.Add(field);
                }
            }
            catch (Exception err) { }
            return fieldList;
        }

        public static void InitializarVariables()
        {
            frmPrincipal.AuthorizationProviderFile = frmPrincipal.AuthorizationDirectory + @"\" + Utils.ProjectName + "AuthorizationProvider.cs";
            frmPrincipal.PermissionNamesFile = frmPrincipal.AuthorizationDirectory + @"\PermissionNames.cs";
            frmPrincipal.AppJsFile = frmPrincipal.WebMainDirectory + @"app.js";
            frmPrincipal.NavigationProviderFile = frmPrincipal.WebDirectory + @"App_Start\"+Utils.ProjectName +"NavigationProvider.cs";
            frmPrincipal.NavBarJSFile = frmPrincipal.ViewsDirectory + @"layout\" + Utils.SideBarFileName;
        }

        public static String ReadTemplate(String TemplateName)
        {
            String tpt = "";
            try
            {
                tpt = System.IO.File.ReadAllText(TemplateDirectory + TemplateName);
            }
            catch (Exception err)
            { }
            return tpt;
        }

        public static String ReadOriginal(String Original)
        {
            String tpt = "";
            try
            {
                tpt = System.IO.File.ReadAllText(Original);
            }
            catch (Exception err)
            { }
            return tpt;
        }
        public static void ReadAllOriginal()    
        {
            InitializarVariables();

            var AuthorizationProviderOriginal = ReadOriginal(frmPrincipal.AuthorizationProviderFile);
            var PermissionNameOriginal = ReadOriginal(frmPrincipal.PermissionNamesFile);
            var AppJsMenuOriginal = ReadOriginal(frmPrincipal.AppJsFile);
            var NavigationProviderOriginal = ReadOriginal(frmPrincipal.NavigationProviderFile);
            var MenuNavBarOriginal = ReadOriginal(frmPrincipal.NavBarJSFile);


            if (!string.IsNullOrEmpty(NavigationProviderOriginal))
                UsingTemplates.NavigationAutorizationCreator.NavigationProviderOriginal = NavigationProviderOriginal;

            if (!string.IsNullOrEmpty(AuthorizationProviderOriginal))
                UsingTemplates.NavigationAutorizationCreator.AuthorizationProviderOriginal = AuthorizationProviderOriginal;

            if (!string.IsNullOrEmpty(PermissionNameOriginal))
                UsingTemplates.NavigationAutorizationCreator.PermissionNamesOriginal = PermissionNameOriginal;

            if (!string.IsNullOrEmpty(AppJsMenuOriginal))
                UsingTemplates.NavigationAutorizationCreator.AppJsOriginal = AppJsMenuOriginal;

            if (!string.IsNullOrEmpty(MenuNavBarOriginal))
                UsingTemplates.NavigationAutorizationCreator.MenuSideBarNavOriginal = MenuNavBarOriginal;

        }

        public static void ReadAllTemplastes()
        {
            var IAppServiceTemplate = ReadTemplate("IAppService.tpt");
            var AppServiceTemplate = ReadTemplate("AppService.tpt");
            var DtoTemplate = ReadTemplate("Dto.tpt");
            var UpdateDtoTemplate = ReadTemplate("UpdateDto.tpt");
            var CreateDtoTemplate = ReadTemplate("CreateDto.tpt");

            var IndexJSTemplate = ReadTemplate("indexJS.tpt");
            var CreateJSTemplate = ReadTemplate("createModalJS.tpt");
            var UpdateJSTemplate = ReadTemplate("editModalJS.tpt");

            var IndexCsHtmlTemplate = ReadTemplate("indexCsHtml.tpt");
            var CreateModalCsHtmlTemplate = ReadTemplate("createModalCsHtml.tpt");
            var EditModalCsHtmlTemplate = ReadTemplate("editModalCsHtml.tpt");

            var FieldNumberTemplate = ReadTemplate("FieldNumberTemplate.tpt");
            var FieldStringTemplate = ReadTemplate("FieldStringTemplate.tpt");
            var FieldDateTimeTemplate = ReadTemplate("FieldDateTimeTemplate.tpt");
            var FieldBooleanTemplate = ReadTemplate("FieldBooleanTemplate.tpt");
            var fieldRelatedTemplate = ReadTemplate("FieldComboTemplate.tpt");
            var fieldRelatedJSTemplate = ReadTemplate("FieldComboTemplateJS.tpt");

            var AuthorizationProviderTemplate = ReadTemplate("AuthorizationProvider.tpt");
            var PermissionNameTemplate = ReadTemplate("PermissionName.tpt");
            var AppJsMenuTemplate = ReadTemplate("AppJsMenu.tpt");
            var NavigationProviderTemplate = ReadTemplate("NavigationProvider.tpt");
            var MenuSideBarNavTemplate = ReadTemplate("MenuSideBarNav.tpt");


            if (!string.IsNullOrEmpty(IAppServiceTemplate))
                IAppServiceCreator.TemplateIAppService = IAppServiceTemplate;

            if (!string.IsNullOrEmpty(AppServiceTemplate))
                AppServiceCreator.TemplateAppService = AppServiceTemplate;

            if (!string.IsNullOrEmpty(DtoTemplate))
                DtosCreator.EntityDto_JustStartLines = DtoTemplate;

            if (!string.IsNullOrEmpty(UpdateDtoTemplate))
                DtosCreator.UpdateDto_JustStartLines = UpdateDtoTemplate;

            if (!string.IsNullOrEmpty(CreateDtoTemplate))
                DtosCreator.CreateDto_JustStartLines = CreateDtoTemplate;

            if (!string.IsNullOrEmpty(IndexJSTemplate))
                UsingTemplates.JSCreator.IndexJS = IndexJSTemplate;

            if (!string.IsNullOrEmpty(CreateJSTemplate))
                UsingTemplates.JSCreator.CreateJS = CreateJSTemplate;

            if (!string.IsNullOrEmpty(UpdateJSTemplate))
                UsingTemplates.JSCreator.UpdateJS = UpdateJSTemplate;

            if (!string.IsNullOrEmpty(IndexCsHtmlTemplate))
                UsingTemplates.CsHtmlCreator.IndexCsHtml = IndexCsHtmlTemplate;

            if (!string.IsNullOrEmpty(CreateModalCsHtmlTemplate))
                UsingTemplates.CsHtmlCreator.CreateModalCsHtml = CreateModalCsHtmlTemplate;

            if (!string.IsNullOrEmpty(EditModalCsHtmlTemplate))
                UsingTemplates.CsHtmlCreator.EditModalCsHtml = EditModalCsHtmlTemplate;

            if (!string.IsNullOrEmpty(FieldNumberTemplate))
                UsingTemplates.CsHtmlCreator.FieldNumber = FieldNumberTemplate;

            if (!string.IsNullOrEmpty(FieldStringTemplate))
                UsingTemplates.CsHtmlCreator.FieldString = FieldStringTemplate;

            if (!string.IsNullOrEmpty(FieldDateTimeTemplate))
                UsingTemplates.CsHtmlCreator.FieldDatetime= FieldDateTimeTemplate;

            if (!string.IsNullOrEmpty(FieldBooleanTemplate))
                UsingTemplates.CsHtmlCreator.FieldBoolean = FieldBooleanTemplate;

            if (!string.IsNullOrEmpty(fieldRelatedTemplate))
                UsingTemplates.CsHtmlCreator.FieldRelated = fieldRelatedTemplate;

            if (!string.IsNullOrEmpty(fieldRelatedJSTemplate))
                UsingTemplates.JSCreator.FieldRelatedJS = fieldRelatedJSTemplate;
            
            if (!string.IsNullOrEmpty(NavigationProviderTemplate))
                UsingTemplates.NavigationAutorizationCreator.NavigationProviderTemplate = NavigationProviderTemplate;

            if (!string.IsNullOrEmpty(AuthorizationProviderTemplate))
                UsingTemplates.NavigationAutorizationCreator.AuthorizationProviderTemplate = AuthorizationProviderTemplate;

            if (!string.IsNullOrEmpty(PermissionNameTemplate))
                UsingTemplates.NavigationAutorizationCreator.PermissionNamesTemplate = PermissionNameTemplate;

            if (!string.IsNullOrEmpty(AppJsMenuTemplate))
                UsingTemplates.NavigationAutorizationCreator.AppJsTemplate = AppJsMenuTemplate;

            if (!string.IsNullOrEmpty(MenuSideBarNavTemplate))
                UsingTemplates.NavigationAutorizationCreator.MenuSideBarNavTemplate = MenuSideBarNavTemplate;
            

        }


    }
}
