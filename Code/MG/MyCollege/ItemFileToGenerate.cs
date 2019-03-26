using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class ItemFileToGenerate
    {
        public ItemFileToGenerate
        (
            int Id,
            string Name,
            string Path,
            string TemplateName,
            string TemplateDirectory,
            ClassInfoData ClassInfoData,
            string ControlName,
            List<ItemFieldTypeTemplate> ItemFieldTypeTemplates = null
        )
        {
            this.Id = Id;
            this.Name = Name;
            this.Path = Path;
            this.TemplateName = TemplateName;
            this.TemplateDirectory = TemplateDirectory;
            this.ItemFieldTypeTemplates = ItemFieldTypeTemplates;
            this.ClassInfoData = ClassInfoData;
            this.ControlName = ControlName;
            this.TemplateMarkup = ReadTemplate();
            ProcessFile();
            this.TemplateMarkup = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string TemplateName { get; set; }
        public string TemplateMarkup { get; set; }
        public string TemplateDirectory { get; set; }
        public ClassInfoData ClassInfoData { get; set; }
        public string ControlName { get; set; }
        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }

        public string GetFieldTypeTemplate(string name)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Name == name)?.TemplateMarkup;
        }

        public string GetFieldTypeTemplate(int id)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Id == id)?.TemplateMarkup;
        }

        private string ReadTemplate()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.TemplateDirectory) && !string.IsNullOrEmpty(this.TemplateName))
                {
                    return System.IO.File.ReadAllText(this.TemplateDirectory + this.TemplateName);
                }
            }
            catch (Exception err)
            { }
            return "";
        }

        public string GetItemToReplaces(string key)
        {
            return ClassInfoData?.ItemToReplaces?.FirstOrDefault(p => p.Key == key)?.Value;
        }

        private string ReplaceAllKeysWithRealValues(string markup)
        {
          
            foreach (var item in ClassInfoData?.ItemToReplaces)
            {
                markup = markup.Replace(item.Key, item.Value);
            }
            
            markup += "\n";
            return markup;
        }

        // this moment i run out of ideas to put this here / when i started to put code static for just one file, i run out of ideas. 
        private void ProcessFile()
        {
            if (this.Id == (int)FileStackId.CreateModalCsHtmlTemplate ||
                this.Id == (int)FileStackId.UpdateCsHtmlTemplate )
            {
                string strinWithFields = GenerateFielListForCreateCsHtml(ClassInfoData.Fields);
                this.TemplateMarkup = this.TemplateMarkup.Replace(@"//XXXFieldsHtmlXXX".ToString(), strinWithFields); 
            }

            if (this.Id == (int)FileStackId.IndexJSTemplate)
            {
                string strinWithFields = GenerateFielListForIndexJs(ClassInfoData.Fields);
                this.TemplateMarkup = this.TemplateMarkup.Replace(@"//XXXFieldsHtmlXXX".ToString(), strinWithFields);
                this.TemplateMarkup = this.TemplateMarkup.Replace(XXXFieldNameCapitalXXX, ClassInfoData.Fields.First().Value.ToString());

            }

            if (this.Id == (int)FileStackId.CreateJSTemplate ||
                this.Id == (int)FileStackId.UpdateJSTemplate)
            {
                string ServiceDeclaration = generateListOfServiceDeclaration(ClassInfoData.Fields);
                string ServiceSetting = generateListOfServiceSetting(ClassInfoData.Fields);
                string ServiceCalls = generateListOfServiceCall(ClassInfoData.Fields);
                this.TemplateMarkup = this.TemplateMarkup.Replace(@"//XXXInsertCallRelatedEntitiesXXX".ToString(), GenerateFielListForCreateJs(ClassInfoData.Fields));
                this.TemplateMarkup = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
                this.TemplateMarkup = this.TemplateMarkup.Replace(XXXFieldNameCapitalXXX, ClassInfoData.Fields.First().Value.ToString());
                this.TemplateMarkup = this.TemplateMarkup.Replace(XXXServicesUsedDeclarationXXX, ServiceDeclaration);
                this.TemplateMarkup = this.TemplateMarkup.Replace(XXXServicesUsedSettingXXX, ServiceSetting);
                this.TemplateMarkup = this.TemplateMarkup.Replace(XXXServiceCallsXXX, ServiceCalls);
                this.TemplateMarkup += "\n";
            }

            if (this.Id == (int)FileStackId.DtoTemplate ||
                this.Id == (int)FileStackId.CreateDtoTemplate ||
                this.Id == (int)FileStackId.UpdateDtoTemplate)
            {
                GenerateDtoTemplate();
            }

            if (this.Id == (int)FileStackId.AppServiceTemplate)
            {
                GenerateAppService();
            }

            if (this.Id == (int)FileStackId.IAppServiceTemplate)
            {
                GenerateIAppService();
            }

            if (this.Id == (int)FileStackId.AuthorizationProviderTemplate)
            {
                GenerateAuthorizationProviderTemplate();
            }

            if (this.Id == (int)FileStackId.MenuSideBarNavTemplate)
            {
                GenerateMenuSideBarNavTemplate();
            }

            if (this.Id == (int)FileStackId.PermissionNameTemplate)
            {
                GeneratePermissionNameTemplate();
            }

            if (this.Id == (int)FileStackId.NavigationProviderTemplate)
            {
                GenerateNavigationProviderTemplate();
            }
            if (this.Id == (int)FileStackId.AppJsMenuTemplate)
            {
                GenerateAppJsMenuTemplate();
            }

        }

        private void GenerateAppJsMenuTemplate()
        {
            var AppJsTemplate = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
            var appJsOriginal = this.GetFieldTypeTemplate("AppJsFile");
            var appJsctualExistente = getLevel("if (abp.auth.hasPermission('", AppJsTemplate, "')").TrimEnd().TrimStart();
            if (!this.GetFieldTypeTemplate("AppJsFile").Contains(appJsctualExistente))
                appJsOriginal = this.GetFieldTypeTemplate("AppJsFile")
                   .Replace(XXXInsertAppJsMenuXXX, AppJsTemplate + "\n\n" + XXXInsertAppJsMenuXXX).Replace("XXXFaIconXXX", ClassInfoData.DefaultIconMenu);

            this.TemplateMarkup = appJsOriginal;

        }

        private void GenerateNavigationProviderTemplate()
        {
            var AuthorizationProviderTemplate = ReplaceAllKeysWithRealValues(this.GetFieldTypeTemplate("AuthorizationProviderTemplate"));
            var autorizacionActualExistente = getLevel("context.CreatePermission(", AuthorizationProviderTemplate, ",").TrimEnd().TrimStart();
            var NavigationProviderTemplate = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
            var navigationProviderOriginal = this.GetFieldTypeTemplate("NavigationProviderFile");
            if (!this.GetFieldTypeTemplate("NavigationProviderFile").Contains(autorizacionActualExistente))
                navigationProviderOriginal = this.GetFieldTypeTemplate("NavigationProviderFile")
                    .Replace(XXXInsertNavitationProviderXXX, NavigationProviderTemplate + "\n\n" + XXXInsertNavitationProviderXXX);

            this.TemplateMarkup = navigationProviderOriginal;
        }

        private void GeneratePermissionNameTemplate()
        {
            var AuthorizationProviderTemplate = ReplaceAllKeysWithRealValues(this.GetFieldTypeTemplate("AuthorizationProviderTemplate"));
            var PermisionNameTemplate = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
            var permissionNameOriginal = this.GetFieldTypeTemplate("PermissionNamesFile");
            var autorizacionActualExistente = getLevel("context.CreatePermission(", AuthorizationProviderTemplate, ",").TrimEnd().TrimStart();
            var permisionNameExistente = autorizacionActualExistente.Replace("PermissionNames.", "");
            if (!this.GetFieldTypeTemplate("PermissionNamesFile").Contains(permisionNameExistente))
                permissionNameOriginal = this.GetFieldTypeTemplate("PermissionNamesFile")
                   .Replace(XXXInsertPermissionNamesXXX, PermisionNameTemplate + "\n\n" + XXXInsertPermissionNamesXXX);

            this.TemplateMarkup = permissionNameOriginal;
        }

        private void GenerateMenuSideBarNavTemplate()
        {
            var MenuSideBarNavTemplate = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
            var MenuSideBarNavOriginal = this.GetFieldTypeTemplate("NavBarJSFile");
            var MenuSideBarExistente = getLevel(",createMenuItem(App.localize(", MenuSideBarNavTemplate, ")").TrimEnd().TrimStart();
            if (!this.GetFieldTypeTemplate("NavBarJSFile").Contains(MenuSideBarExistente))
                MenuSideBarNavOriginal = this.GetFieldTypeTemplate("NavBarJSFile")
                   .Replace(XXXInsertMenuItemXXX, MenuSideBarNavTemplate + "\n\n" + XXXInsertMenuItemXXX);

            this.TemplateMarkup = MenuSideBarNavOriginal;
        }

        private void GenerateAuthorizationProviderTemplate()
        {
            var AuthorizationProviderTemplate = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
            var authorizationProviderOriginal = this.GetFieldTypeTemplate("AuthorizationProviderFile");
            var autorizacionActualExistente = getLevel("context.CreatePermission(", AuthorizationProviderTemplate, ",").TrimEnd().TrimStart();
            if (!this.GetFieldTypeTemplate("AuthorizationProviderFile").Contains(autorizacionActualExistente))
                authorizationProviderOriginal = this.GetFieldTypeTemplate("AuthorizationProviderFile")
                    .Replace(XXXInsertAuthorizationProviderXXX, AuthorizationProviderTemplate + "\n\n" + XXXInsertAuthorizationProviderXXX);

            this.TemplateMarkup = authorizationProviderOriginal;
        }

        public string getLevel(string except, string valorCompleto, string removeFinal)
        {
            var valorSinFinal = "";

            if (!string.IsNullOrEmpty(removeFinal))
            {
                var indiceElementoFinal = valorCompleto.IndexOf(removeFinal);
                valorSinFinal = valorCompleto.Substring(0, indiceElementoFinal);
            }
            else
                valorSinFinal = valorCompleto;
            return valorSinFinal.Replace(except, "").TrimEnd().TrimStart();
        }

        private void GenerateIAppService()
        {
            var stringDataIAppService = this.TemplateMarkup.Replace(XXXEntitySingularXXX, ClassInfoData.XXXEntitySingularXXX);
            stringDataIAppService = stringDataIAppService.Replace(XXXEntityPluralXXX, ClassInfoData.XXXEntityPluralXXX);
            stringDataIAppService = stringDataIAppService.Replace(XXXProjectNameXXX, ClassInfoData.GetItemToReplace(XXXProjectNameXXX));
            stringDataIAppService = ReplaceAllKeyTypes(stringDataIAppService);
            this.TemplateMarkup = stringDataIAppService;
        }

        private void GenerateAppService()
        {

            List<TripleValue<string, string, string, String>> fielListUsed = ClassInfoData.Fields;
            if (fielListUsed.Count == 0)
                return;

            string FirstStringField = "";
            if (fielListUsed.Any(x => x.Value == "Name"))
                FirstStringField = "Name";

            if (FirstStringField == "")
            {
                var stringf = fielListUsed.FirstOrDefault(x => x.Key.ToLower() == "string");
                if (stringf != null)
                    FirstStringField = stringf.Value;
            }
            if (FirstStringField == "")
            {
                var stringf = fielListUsed.FirstOrDefault(x => x.Value.ToLower() != "hoscodigo");
                if (stringf != null)
                    FirstStringField = stringf.Value;
            }

            // TODO
            //AddLocalization("CreateNew" + txtCapitalSingular.Text);
            //AddLocalization("Edit" + txtCapitalSingular.Text);
            //AddLocalization("New" + txtCapitalSingular.Text);
            //AddLocalization(txtCapitalPlural.Text);

            var stringDataIAppService = this.TemplateMarkup.Replace(XXXEntitySingularXXX, ClassInfoData.XXXEntitySingularXXX);

            //AddLocalization(txtCapitalSingular.Text);
            stringDataIAppService = stringDataIAppService.Replace(XXXEntityPluralXXX, ClassInfoData.XXXEntityPluralXXX);
            stringDataIAppService = stringDataIAppService.Replace(XXXProjectNameXXX, ClassInfoData.GetItemToReplace(XXXProjectNameXXX));
            stringDataIAppService = ReplaceAllKeyTypes(stringDataIAppService);
            //rtbIAppSericeGenerator.Clear();
            //rtbIAppSericeGenerator.AppendText(stringDataIAppService);

            String StringWitRepositoryDeclarationList = generateListOfRepositoryDeclaration(fielListUsed);
            String StringWitRepositoryConstructorList = generateListOfRepositoryContructor(fielListUsed);
            String StringWitRepositorySettingList = generateListOfRepositorySetting(fielListUsed);

            var stringDataAppService = this.TemplateMarkup.Replace(XXXEntitySingularXXX, ClassInfoData.XXXEntitySingularXXX);

            var FieldAlternativeSequence = "";

            if (fielListUsed.Any(x => x.Value.Contains("Sequence")))
                FieldAlternativeSequence = "Sequence";
            else if (fielListUsed.Any(x => x.Value.Contains("Number")))
                FieldAlternativeSequence = "Number";

            if (FieldAlternativeSequence.Length > 0)
            {
                var newSequenceString = @"
                var sequence = 1;
                try
                {
                    using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete, AbpDataFilters.MustHaveTenant))
                    {
                        sequence = _mcTransactionRepository.GetAllList(x => x.TenantId == AbpSession.TenantId).Max(x => x.xxxSequencexxx) + 1;
                    }
                }
                catch{}
                message.xxxSequencexxx = sequence;
            ";


                stringDataAppService = stringDataAppService.Replace("//XXXInsertAlternativeSequenceXXX", newSequenceString);

                stringDataAppService = stringDataAppService.Replace("xxxSequencexxx", FieldAlternativeSequence);
            }


            stringDataAppService = ReplaceAllKeysWithRealValues(stringDataAppService);
            stringDataAppService = stringDataAppService.Replace(XXXRepositoryDeclarationListXXX, StringWitRepositoryDeclarationList);
            stringDataAppService = stringDataAppService.Replace(XXXRepositoryConstructorListXXX, StringWitRepositoryConstructorList);
            stringDataAppService = stringDataAppService.Replace(XXXRepositorySettingListXXX, StringWitRepositorySettingList);
            stringDataAppService = ReplaceAllKeyTypes(stringDataAppService);

            stringDataAppService = stringDataAppService.Replace("x.Name.Contains", "x." + FirstStringField + ".Contains");
            stringDataAppService = stringDataAppService.Replace("r.Name", "r." + FirstStringField);




            //rtbAppSericeGenerator.Clear();

            //rtbAppSericeGenerator.AppendText(stringDataAppService);

            //ClassPath = ClassesPath + txtCapitalPlural.Text + ".cs";

            //var LoadedClass = System.IO.File.ReadAllLines(ClassPath);

            //String CallRelatedEntities = "";

            //FielList = GenerateDtos(LoadedClass);

            //List<string> FielListForIndexJs = GenerateFielListForIndexJs(FielList, out CallRelatedEntities);
            //List<string> FielListForCreateCsHtml = GenerateFielListForCreateCsHtml(FielList);

            //GenerateJsFiles(FielList, FielListForIndexJs, CallRelatedEntities);

            //GenerateCsHtmlFiles(FielListForCreateCsHtml);

            //GenerateNavigationYAuthorizationEditions();

            //for (int i = 0; i < ListOfLocalizationKeys.Count; i++)
            //{
            //    ListOfLocalizationKeys[i] = ListOfLocalizationKeys[i].Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
            //    Localizations.AppendText(ListOfLocalizationKeys[i] + "\n");
            //}


        }

        private string generateListOfRepositoryDeclaration(List<TripleValue<string, string, string, String>> fielList)
        {
            var RelatedEntities = "\n";
            foreach (var item in fielList)
            {
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = "		    private readonly IRepository<Models.XXXEntityPluralXXX, int> _XXXEntityLowerSingularXXXRepository;";
                    templateSeletedted = templateSeletedted.Replace(XXXEntityPluralXXX, comboParameter.EntityPlural);
                    templateSeletedted = templateSeletedted.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);

                    RelatedEntities += templateSeletedted + "\n";
                }
            }
            return RelatedEntities;
        }

        private string generateListOfRepositoryContructor(List<TripleValue<string, string, string, String>> fielList)
        {
            var RelatedEntities = "";
            foreach (var item in fielList)
            {
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = ",\n            IRepository<Models.XXXEntityPluralXXX, int> XXXEntityLowerSingularXXXRepository";
                    templateSeletedted = templateSeletedted.Replace(XXXEntityPluralXXX, comboParameter.EntityPlural);
                    templateSeletedted = templateSeletedted.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);

                    RelatedEntities += templateSeletedted + "\n";
                }
            }
            return RelatedEntities;
        }

        private string generateListOfRepositorySetting(List<TripleValue<string, string, string, String>> fielList)
        {
            var RelatedEntities = "\n";
            foreach (var item in fielList)
            {


                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = "            _XXXEntityLowerSingularXXXRepository = XXXEntityLowerSingularXXXRepository;\n";
                    templateSeletedted = templateSeletedted.Replace(XXXEntityPluralXXX, comboParameter.EntityPlural);
                    templateSeletedted = templateSeletedted.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);

                    RelatedEntities += templateSeletedted + "\n";
                }
            }
            return RelatedEntities;
        }

        private void GenerateDtoTemplate()
        {
            this.TemplateMarkup = ReplaceAllKeysWithRealValues(this.TemplateMarkup);

            this.TemplateMarkup += "              public int Id {get;set;} \n";

            foreach (var item in ClassInfoData.Fields)
            {
                if (this.Id == (int)FileStackId.DtoTemplate)
                {
                    this.TemplateMarkup += "              public " + item.Key + " " + item.Value + " {get;set;} \n";
                }
                if (this.Id == (int)FileStackId.CreateDtoTemplate)
                {
                    this.TemplateMarkup += (!string.IsNullOrEmpty(item.ValueAlt) ? "\n              [StringLength(" + item.ValueAlt + ")] " : "")
                    + "\n              public " + item.Key + " " + item.Value + " {get;set;} \n";
                }
                if (this.Id == (int)FileStackId.UpdateDtoTemplate)
                {
                    this.TemplateMarkup += (!string.IsNullOrEmpty(item.ValueAlt) ? "\n              [StringLength(" + item.ValueAlt + ")]  " : "")
                    + "\n              public " + item.Key + " " + item.Value + " {get;set;} \n";
                }
            }

            this.TemplateMarkup += "              public bool IsActive {get;set;} \n";
            this.TemplateMarkup += "              public DateTime CreationTime {get;set;} \n";
            this.TemplateMarkup += "              public long? CreatorUserId {get;set;} \n";
            this.TemplateMarkup += "\n         }\n}";

            this.TemplateMarkup = ReplaceAllKeyTypes(this.TemplateMarkup);
        }

        private string ReplaceAllKeyTypes(string AllStrings)
        {
            var returnedStrings = AllStrings.Replace(", int,", ", " + ClassInfoData.SpecificType + ",");
            returnedStrings = returnedStrings.Replace(",int,", "," + ClassInfoData.SpecificType + ",");
            returnedStrings = returnedStrings.Replace("<int>", "<" + ClassInfoData.SpecificType + ">");
            returnedStrings = returnedStrings.Replace("int> _" + GetItemToReplaces("XXXEntityLowerSingularXXX") + "Repository", ClassInfoData.SpecificType + "> _" + GetItemToReplaces("XXXEntityLowerSingularXXX") + "Repository");
            returnedStrings = returnedStrings.Replace("int> " + GetItemToReplaces("XXXEntityLowerSingularXXX") + "Repository", ClassInfoData.SpecificType + "> " + GetItemToReplaces("XXXEntityLowerSingularXXX") + "Repository");
            returnedStrings = returnedStrings.Replace("int> repository", ClassInfoData.SpecificType + "> repository");
            returnedStrings = returnedStrings.Replace("int> _bank", ", " + ClassInfoData.SpecificType + ",");
            returnedStrings = returnedStrings.Replace("EntityDto<int>", "EntityDto<" + ClassInfoData.SpecificType + ">");


            return returnedStrings;
        }

        private string generateListOfServiceDeclaration(List<TripleValue<string, string, string, String>> fielList)
        {
            var RelatedEntities = "";
            foreach (var item in fielList)
            {


                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = "'abp.services.app.XXXEntityLowerSingularXXX',";
                    templateSeletedted = templateSeletedted.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);

                    RelatedEntities += templateSeletedted + "";
                }
            }
            return RelatedEntities;
        }

        private string generateListOfServiceSetting(List<TripleValue<string, string, string, String>> fielList)
        {
            var RelatedEntities = "";
            foreach (var item in fielList)
            {
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = ", XXXEntityLowerSingularXXXService";
                    templateSeletedted = templateSeletedted.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);
                    RelatedEntities += templateSeletedted + "";
                }
            }
            return RelatedEntities;
        }

        private string generateListOfServiceCall(List<TripleValue<string, string, string, String>> fielList)
        {
            var RelatedEntities = "";
            foreach (var item in fielList)
            {
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = "                vm.getXXXEntityPluralXXX();\n";
                    templateSeletedted = templateSeletedted.Replace(XXXEntityPluralXXX, comboParameter.EntityPlural);
                    RelatedEntities += templateSeletedted + "";
                }
            }
            return RelatedEntities;
        }

        private string GenerateFielListForIndexJs(List<TripleValue<string, string, string, String>> fielList)
        {
            var fieldListForIndexJs = new List<string>();
            foreach (var item in fielList)
            {
                string newField = "";
                newField += "                    {\n";
                newField += "                    name: App.localize('XXXEntitySingularXXX" + item.Value + "'),\n";
                //AddLocalization(txtCapitalSingular.Text + item.Value);
                //AddLocalization(item.Value);
                //TODO
                newField += "                    field: '" + item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1) + "',\n";
                newField += "                    minWidth: 125\n";
                newField += "                    },\n";
                fieldListForIndexJs.Add(newField);
            }

            return string.Join("", fieldListForIndexJs.ToArray());
        }

        private string GenerateFielListForCreateJs(List<TripleValue<string, string, string, String>> fielList)
        {
            string RelatedEntities = "//XXXInsertCallRelatedEntitiesXXX\n\n";
            List<string> fieldListForIndexJs = new List<string>();
            foreach (var item in fielList)
            {
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    var templateSeletedted = UsingTemplates.JSCreator.FieldRelatedJS;
                    templateSeletedted = templateSeletedted.Replace(XXXFieldNameCamelPluralXXX, comboParameter.EntityCamelPlural);
                    templateSeletedted = templateSeletedted.Replace(XXXFieldNameCapitalPluralXXX, comboParameter.EntityPlural);
                    templateSeletedted = templateSeletedted.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);

                    RelatedEntities += templateSeletedted + "\n\n";
                }

            }

            return RelatedEntities;
        }

        private string XXXServiceCallsXXX = "XXXServiceCallsXXX";
        private string XXXInsertPermissionNamesXXX = "//XXXInsertPermissionNamesXXX";
        private string XXXInsertNavitationProviderXXX = "//XXXInsertNavitationProviderXXX";
        private string XXXInsertAuthorizationProviderXXX = "//XXXInsertAuthorizationProviderXXX";
        private string XXXInsertAppJsMenuXXX = "//XXXInsertAppJsMenuXXX";
        private string XXXFieldKeyXXX = "XXXFieldKeyXXX";

        private string XXXRepositoryConstructorListXXX = "XXXRepositoryConstructorListXXX";

        private string XXXEntityPluralXXX = "XXXEntityPluralXXX";
        private string XXXEntitySingularXXX = "XXXEntitySingularXXX";
        private string XXXEntityLowerSingularXXX = "XXXEntityLowerSingularXXX";
        private string XXXInsertMenuItemXXX = "//XXXInsertMenuItemXXX";

        private string XXXServicesUsedDeclarationXXX = "XXXServicesUsedDeclarationXXX";
        private string XXXServicesUsedSettingXXX = "XXXServicesUsedSettingXXX";

        private string XXXFieldNameCamelXXX = "XXXFieldNameCamelXXX";
        private string XXXFieldNameCapitalXXX = "XXXFieldNameCapitalXXX";
        private string XXXFieldNameCapitalPluralXXX = "XXXFieldNameCapitalPluralXXX";
        private string XXXFieldNameCamelSingularXXX = "XXXFieldNameCamelSingularXXX";

        private string XXXrequiredXXX = "XXXrequiredXXX";
        private string XXXProjectNameXXX = "XXXProjectNameXXX";

        private static string XXXRepositorySettingListXXX = "XXXRepositorySettingListXXX";
        private static string XXXRepositoryDeclarationListXXX = "XXXRepositoryDeclarationListXXX";

        private string XXXFieldNameCapitalSingularXXX = "XXXFieldNameCapitalSingularXXX";
        private string XXXFieldNameCamelPluralXXX = "XXXFieldNameCamelPluralXXX";

        private string GenerateFielListForCreateCsHtml(List<TripleValue<string, string, string, string>> fielList)
        {
            var fieldListForIndexCsHtml = new List<string>();

            var FieldStringTemplate = GetFieldTypeTemplate("FieldStringTemplate"); // UsingTemplates.CsHtmlCreator.FieldString;
            FieldStringTemplate = ReplaceAllKeysWithRealValues(FieldStringTemplate);
            
            var FieldDateTimeTemplate = GetFieldTypeTemplate("FieldDateTimeTemplate"); //UsingTemplates.CsHtmlCreator.FieldDatetime;
            FieldDateTimeTemplate = ReplaceAllKeysWithRealValues(FieldDateTimeTemplate);

            var FieldBooleanTemplate = GetFieldTypeTemplate("FieldBooleanTemplate"); //UsingTemplates.CsHtmlCreator.FieldBoolean;
            FieldBooleanTemplate = ReplaceAllKeysWithRealValues(FieldBooleanTemplate);

            var FieldNumberTemplate = GetFieldTypeTemplate("FieldNumberTemplate"); //UsingTemplates.CsHtmlCreator.FieldNumber;
            FieldNumberTemplate = ReplaceAllKeysWithRealValues(FieldNumberTemplate);

            var FieldRelatedTemplate = GetFieldTypeTemplate("FieldComboTemplate");
            FieldRelatedTemplate = ReplaceAllKeysWithRealValues(FieldRelatedTemplate);

            foreach (var item in fielList)
            {
                //Commented for now.
                //AddLocalization(txtCapitalSingular.Text + item.Value);
                string isRequired = "required";
                string nameCamel = item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1);
                string newField = "";

                //Si el campo indicado esta como un combo ( en la lista de combos), se crea el combo y en caso contrario otro tipo de campo.
                var comboParameter = GetComboParameter(item.Value);
                if (comboParameter != null)
                {
                    string fieldForAngular = item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1);
                    newField = FieldRelatedTemplate.Replace(XXXFieldKeyXXX, fieldForAngular);
                    newField = newField.Replace(XXXFieldNameCamelXXX, comboParameter.FieldNameValue.Substring(0, 1).ToLower() + comboParameter.FieldNameValue.Substring(1));
                    newField = newField.Replace(XXXEntityLowerSingularXXX, comboParameter.EntityCamelSingular);
                    newField = newField.Replace(XXXFieldNameCamelPluralXXX, comboParameter.EntityCamelPlural);
                    newField = newField.Replace(XXXFieldNameCapitalXXX, comboParameter.EntitySingular);
                    newField = newField.Replace(XXXFieldNameCamelSingularXXX, comboParameter.EntityCamelSingular);
                    newField = newField.Replace(XXXFieldNameCapitalSingularXXX, comboParameter.EntitySingular);
                }
                else
                {
                    if (item.Key == "String" || item.Key == "string")
                    {
                        newField = FieldStringTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                        newField = newField.Replace("XXXMaxLengthXXX", string.IsNullOrEmpty(item.ValueAlt) ? "" : "maxlength=\"" + item.ValueAppened + "\" \n");
                        newField = newField.Replace("XXXMaxLengthmdXXX", string.IsNullOrEmpty(item.ValueAlt) ? "" : "md-maxlength=\"" + item.ValueAppened + "\" \n");
                    }

                    if (item.Key == "int" || item.Key == "long" || item.Key == "decimal" || item.Key == "Decimal" || item.Key == "double"
                        || item.Key == "Double" || item.Key == "Integer" || item.Key == "Int64" || item.Key == "Int32" || item.Key == "Int16")
                    {
                        newField = FieldNumberTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                    }

                    if (item.Key == "bool" || item.Key == "Bool" || item.Key == "Boolean" || item.Key == "boolean")
                    {
                        newField = FieldBooleanTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                    }

                    if (item.Key == "datetime" || item.Key == "DateTime" || item.Key == "Date" || item.Key == "date")
                    {
                        newField = FieldDateTimeTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);
                    }

                    newField = newField.Replace(XXXFieldNameCapitalXXX, item.Value);
                    newField = newField.Replace(XXXrequiredXXX, isRequired);
                }
                fieldListForIndexCsHtml.Add(newField);
            }

            return string.Join("", fieldListForIndexCsHtml.ToArray());
        }

        private ComboParameter GetComboParameter(string FieldNameValue)
        {
            return this.ClassInfoData?.ComboParameters?.FirstOrDefault(p=>p.FieldNameValue == FieldNameValue);
        }

    }
}
