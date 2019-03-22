using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class CrudGenerator
    {
        public Configuration Configuration { get; set; }
        public string Version { get { return Configuration.Version; } }
        public string TemplateDirectory { get { return Configuration.TemplateDirectory; } }
        public string ProjectName { get { return Configuration.ProjectName; } }

        public List<ItemToReplace> ItemToReplaces { get; set; }
        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }
        public List<ItemFileToGenerate> ItemFileToGenerates { get; set; }

        public string GetItemToReplaces(string key)
        {
            return ItemToReplaces.FirstOrDefault(p => p.Key == key)?.Value;
        }

        public CrudGenerator(Configuration Configuration, List<ItemToReplace> ItemToReplaces)
        {
            this.ItemToReplaces = ItemToReplaces;

            Configuration.AddConfig(new ItemConfig
            {
                Name = "ViewDirectory",
                Value = Configuration.GetConfig("ViewsDirectory") + GetItemToReplaces("XXXEntityLowerPluralXXX")
            });

            Configuration.AddConfig(new ItemConfig
            {
                Name = "ClassPath",
                Value = Configuration.GetConfig("ClassesPath") + GetItemToReplaces("XXXEntityPluralXXX") + ".cs"
            });

            // string PathDirectoryAppService = pathDirectoryApp + txtCapitalPlural.Text;

            this.Configuration = Configuration;
            LoadItemFileToCreate();
        }

        private void LoadItemFileToCreate()
        {
            ItemFileToGenerates = new List<ItemFileToGenerate>()
            {
                new ItemFileToGenerate
                (
                    Id: 100,
                    Name: "IndexCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\index.cshtml",
                    TemplateName: "indexCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemFieldTypePlaceHolder: "",
                    ItemToReplaces: ItemToReplaces
                ),
                new ItemFileToGenerate
                (
                    Id: 110,
                    Name: "CreateModalCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\createModal.cshtml",
                    TemplateName: "createModalCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemFieldTypePlaceHolder: "",
                    ItemToReplaces: ItemToReplaces
                ),
                new ItemFileToGenerate
                (
                    Id: 105,
                    Name: "UpdateCsHtmlTemplate",
                    Path: Configuration.GetConfig("ViewDirectory") + @"\editModal.cshtml",
                    TemplateName: "createModalCsHtml.tpt",
                    TemplateDirectory: TemplateDirectory,
                    ItemFieldTypePlaceHolder: "",
                    ItemToReplaces: ItemToReplaces
                ),
                

            };

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

        public List<string> ListOfLocalizationKeys { get; set; }
        public string ProjectName { get; internal set; }
        public string Version { get; internal set; }

        public void AddLocalization(String loca)
        {
            if (ListOfLocalizationKeys == null)
                ListOfLocalizationKeys = new List<string>();
            if (ListOfLocalizationKeys.Any(x => x == loca))
                return;
            if (loca.ToUpper() == "NAME")
                return;
            ListOfLocalizationKeys.Add(loca);
        }

      
        public string XXXServiceCallsXXX = "XXXServiceCallsXXX";
        public static string XXXRepositoryConstructorListXXX = "XXXRepositoryConstructorListXXX";

        public static string GetMaxLengString(string Line)
        {
            string maxlenghtX = string.Empty;
            string buscado = "Length(";

            var index = Line.IndexOf(buscado);
            if (index < 0)
                return maxlenghtX;
            var indexEndMaxLeng = Line.IndexOf(")", index);

            maxlenghtX = Line.Substring(index + buscado.Length, indexEndMaxLeng - (index + buscado.Length));
            return maxlenghtX;
        }

        public static string GetMaxLengIntForString(string Line)
        {
            string maxlenghtX = string.Empty;
            string buscado = "Length(";

            var index = Line.IndexOf(buscado);
            if (index < 0)
                return maxlenghtX;
            var indexEndMaxLeng = Line.IndexOf(",", index);
            if (indexEndMaxLeng < 0)
                indexEndMaxLeng = Line.IndexOf(")", index);

            maxlenghtX = Line.Substring(index + buscado.Length, indexEndMaxLeng - (index + buscado.Length));
            return maxlenghtX;
        }

        internal void btnGenerate_Click(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        public static string XXXRepositorySettingListXXX = "XXXRepositorySettingListXXX";
        public static string XXXRepositoryDeclarationListXXX = "XXXRepositoryDeclarationListXXX";

        public string XXXFirstFieldNameXXX = "XXXFirstFieldNameXXX";

        public string XXXFieldNameCapitalSingularXXX = "XXXFieldNameCapitalSingularXXX";
        public string XXXFieldNameCamelPluralXXX = "XXXFieldNameCamelPluralXXX";

        public static string ClassPath = "";
        public static string DtosPathTemp;
        private string fileNameIndexCsHtml = "";
        private string fileNameEditCsHtml = "";

        public List<string> getFieldListFromEntity(string text)
        {
            throw new NotImplementedException();
        }

        private string fileNameCreateCsHtml = "";

        private string XXXInsertPermissionNamesXXX = "//XXXInsertPermissionNamesXXX";
        private string XXXInsertNavitationProviderXXX = "//XXXInsertNavitationProviderXXX";
        private string XXXInsertAuthorizationProviderXXX = "//XXXInsertAuthorizationProviderXXX";
        private string XXXInsertAppJsMenuXXX = "//XXXInsertAppJsMenuXXX";
        private string XXXFieldKeyXXX = "XXXFieldKeyXXX";

        private string XXXEntityPluralXXX = "XXXEntityPluralXXX";
        private string XXXEntitySingularXXX = "XXXEntitySingularXXX";
        private string XXXEntityLowerSingularXXX = "XXXEntityLowerSingularXXX";
        private string XXXEntityLowerPluralXXX = "XXXEntityLowerPluralXXX";
        private string XXXInsertMenuItemXXX = "//XXXInsertMenuItemXXX";

        private string XXXServicesUsedDeclarationXXX = "XXXServicesUsedDeclarationXXX";
        private string XXXServicesUsedSettingXXX = "XXXServicesUsedSettingXXX";

        private string XXXFieldNameCamelXXX = "XXXFieldNameCamelXXX";
        private string XXXFieldNameCapitalXXX = "XXXFieldNameCapitalXXX";
        private string XXXFieldNameCapitalPluralXXX = "XXXFieldNameCapitalPluralXXX";
        private string XXXFieldNameCamelSingularXXX = "XXXFieldNameCamelSingularXXX";

        private string XXXrequiredXXX = "XXXrequiredXXX";
        private string XXXProjectNameXXX = "XXXProjectNameXXX";

        private void txtEntityNameSingular_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string camell = "";
                var lower = txtCamelSingular.Text;
                if (lower.ToLower().Substring(lower.Length - 1, 1) == "s")
                    camell = lower + "es";
                else if (lower.ToLower().Substring(lower.Length - 1, 1) == "y" &&
                    (
                        (lower.ToLower().Substring(lower.Length - 2, 1) != "a") &&
                    (lower.ToLower().Substring(lower.Length - 2, 1) != "e") &&
                    (lower.ToLower().Substring(lower.Length - 2, 1) != "i") &&
                    (lower.ToLower().Substring(lower.Length - 2, 1) != "o") &&
                    (lower.ToLower().Substring(lower.Length - 2, 1) != "u")

                    )
                    )
                {
                    camell = lower.Substring(0, lower.Length - 1) + "ies";
                }
                else
                    camell = lower + "s";


                var capital = camell.Substring(0, 1).ToUpper() + camell.Substring(1);
                var capitalSingular = lower.Substring(0, 1).ToUpper() + lower.Substring(1);

                txtCamelPlural.Text = camell;
                txtCapitalPlural.Text = capital;
                txtCapitalSingular.Text = capitalSingular;

                btnGenerate_Click(null, null);
            }
            catch (Exception err)
            { }
        }


        List<TripleValue<String, String, String, String>> FielList = new List<TripleValue<string, string, string, String>>();

        public bool ExistInFielList(String field)
        {
            return FielList.Any(x => x.Value == field);
        }

        public bool ExistInRelatedFielList(String field)
        {
            return fieldsRelatedEntity.Any(x => x.Value == field);
        }

        public string ReplaceAllKeyTypes(string AllStrings)
        {
            var returnedStrings = AllStrings.Replace(", int,", ", " + Utils.SpecificType + ",");
            returnedStrings = returnedStrings.Replace(",int,", "," + Utils.SpecificType + ",");
            returnedStrings = returnedStrings.Replace("<int>", "<" + Utils.SpecificType + ">");
            returnedStrings = returnedStrings.Replace("int> _" + txtCamelSingular.Text + "Repository", Utils.SpecificType + "> _" + txtCamelSingular.Text + "Repository");
            returnedStrings = returnedStrings.Replace("int> " + txtCamelSingular.Text + "Repository", Utils.SpecificType + "> " + txtCamelSingular.Text + "Repository");
            returnedStrings = returnedStrings.Replace("int> repository", Utils.SpecificType + "> repository");
            returnedStrings = returnedStrings.Replace("int> _bank", ", " + Utils.SpecificType + ",");
            returnedStrings = returnedStrings.Replace("EntityDto<int>", "EntityDto<" + Utils.SpecificType + ">");


            return returnedStrings;
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ListOfLocalizationKeys = null;
            cleanRiches();
            List<TripleValue<string, string, string, String>> fielListUsed = Utils.getFieldListFromEntity(txtCapitalSingular.Text);
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

            AddLocalization("CreateNew" + txtCapitalSingular.Text);
            AddLocalization("Edit" + txtCapitalSingular.Text);
            AddLocalization("New" + txtCapitalSingular.Text);
            AddLocalization(txtCapitalPlural.Text);

            var stringDataIAppService = IAppServiceCreator.TemplateIAppService.Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
            AddLocalization(txtCapitalSingular.Text);
            stringDataIAppService = stringDataIAppService.Replace(XXXEntityPluralXXX, txtCapitalPlural.Text);
            stringDataIAppService = stringDataIAppService.Replace(XXXProjectNameXXX, Utils.ProjectName);
            stringDataIAppService = ReplaceAllKeyTypes(stringDataIAppService);
            rtbIAppSericeGenerator.Clear();
            rtbIAppSericeGenerator.AppendText(stringDataIAppService);


            String StringWitRepositoryDeclarationList = generateListOfRepositoryDeclaration(fielListUsed);
            String StringWitRepositoryConstructorList = generateListOfRepositoryContructor(fielListUsed);
            String StringWitRepositorySettingList = generateListOfRepositorySetting(fielListUsed);

            var stringDataAppService = AppServiceCreator.TemplateAppService.Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);

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




            rtbAppSericeGenerator.Clear();



            rtbAppSericeGenerator.AppendText(stringDataAppService);

            ClassPath = ClassesPath + txtCapitalPlural.Text + ".cs";

            var LoadedClass = System.IO.File.ReadAllLines(ClassPath);

            String CallRelatedEntities = "";
            FielList = GenerateDtos(LoadedClass);
            List<string> FielListForIndexJs = GenerateFielListForIndexJs(FielList, out CallRelatedEntities);
            List<string> FielListForCreateCsHtml = GenerateFielListForCreateCsHtml(FielList);

            GenerateJsFiles(FielList, FielListForIndexJs, CallRelatedEntities);

            GenerateCsHtmlFiles(FielListForCreateCsHtml);

            GenerateNavigationYAuthorizationEditions();

            for (int i = 0; i < ListOfLocalizationKeys.Count; i++)
            {
                ListOfLocalizationKeys[i] = ListOfLocalizationKeys[i].Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
                Localizations.AppendText(ListOfLocalizationKeys[i] + "\n");
            }


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

        private void GenerateNavigationYAuthorizationEditions()
        {

            var MenuSideBarNavTemplate = ReplaceAllKeysWithRealValues(UsingTemplates.NavigationAutorizationCreator.MenuSideBarNavTemplate);
            var PermisionNameTemplate = ReplaceAllKeysWithRealValues(UsingTemplates.NavigationAutorizationCreator.PermissionNamesTemplate);
            var NavigationProviderTemplate = ReplaceAllKeysWithRealValues(UsingTemplates.NavigationAutorizationCreator.NavigationProviderTemplate);
            var AuthorizationProviderTemplate = ReplaceAllKeysWithRealValues(UsingTemplates.NavigationAutorizationCreator.AuthorizationProviderTemplate);
            var AppJsTemplate = ReplaceAllKeysWithRealValues(UsingTemplates.NavigationAutorizationCreator.AppJsTemplate);



            var authorizationProviderOriginal = UsingTemplates.NavigationAutorizationCreator.AuthorizationProviderOriginal;
            var autorizacionActualExistente = getLevel("context.CreatePermission(", AuthorizationProviderTemplate, ",").TrimEnd().TrimStart();
            if (!UsingTemplates.NavigationAutorizationCreator.AuthorizationProviderOriginal.Contains(autorizacionActualExistente))
                authorizationProviderOriginal = UsingTemplates.NavigationAutorizationCreator.AuthorizationProviderOriginal
                    .Replace(XXXInsertAuthorizationProviderXXX, AuthorizationProviderTemplate + "\n\n" + XXXInsertAuthorizationProviderXXX);



            var permissionNameOriginal = UsingTemplates.NavigationAutorizationCreator.PermissionNamesOriginal;
            var permisionNameExistente = autorizacionActualExistente.Replace("PermissionNames.", "");
            if (!UsingTemplates.NavigationAutorizationCreator.PermissionNamesOriginal.Contains(permisionNameExistente))
                permissionNameOriginal = UsingTemplates.NavigationAutorizationCreator.PermissionNamesOriginal
                   .Replace(XXXInsertPermissionNamesXXX, PermisionNameTemplate + "\n\n" + XXXInsertPermissionNamesXXX);


            var appJsOriginal = UsingTemplates.NavigationAutorizationCreator.AppJsOriginal;
            var appJsctualExistente = getLevel("if (abp.auth.hasPermission('", AppJsTemplate, "')").TrimEnd().TrimStart();
            if (!UsingTemplates.NavigationAutorizationCreator.AppJsOriginal.Contains(appJsctualExistente))
                appJsOriginal = UsingTemplates.NavigationAutorizationCreator.AppJsOriginal
                   .Replace(XXXInsertAppJsMenuXXX, AppJsTemplate + "\n\n" + XXXInsertAppJsMenuXXX).Replace("XXXFaIconXXX", txtFaIcon.Text);


            var navigationProviderOriginal = UsingTemplates.NavigationAutorizationCreator.NavigationProviderOriginal;
            if (!UsingTemplates.NavigationAutorizationCreator.NavigationProviderOriginal.Contains(autorizacionActualExistente))
                navigationProviderOriginal = UsingTemplates.NavigationAutorizationCreator.NavigationProviderOriginal
                    .Replace(XXXInsertNavitationProviderXXX, NavigationProviderTemplate + "\n\n" + XXXInsertNavitationProviderXXX);



            var MenuSideBarNavOriginal = UsingTemplates.NavigationAutorizationCreator.MenuSideBarNavOriginal;
            var MenuSideBarExistente = getLevel(",createMenuItem(App.localize(", MenuSideBarNavTemplate, ")").TrimEnd().TrimStart();
            if (!UsingTemplates.NavigationAutorizationCreator.MenuSideBarNavOriginal.Contains(MenuSideBarExistente))
                MenuSideBarNavOriginal = UsingTemplates.NavigationAutorizationCreator.MenuSideBarNavOriginal
                   .Replace(XXXInsertMenuItemXXX, MenuSideBarNavTemplate + "\n\n" + XXXInsertMenuItemXXX);

            rtbAppJsGenerator.Clear();
            rtbAutorizationProviderGenerator.Clear();
            rtbPermissionNameGenerator.Clear();
            rtbNavigationProviderGenerator.Clear();
            rtbMenuNavBarGenerator.Clear();

            rtbAppJsGenerator.Text = appJsOriginal;
            rtbAutorizationProviderGenerator.Text = authorizationProviderOriginal;
            rtbPermissionNameGenerator.Text = permissionNameOriginal;
            rtbNavigationProviderGenerator.Text = navigationProviderOriginal;
            rtbMenuNavBarGenerator.Text = MenuSideBarNavOriginal;

        }

        private void cleanRiches()
        {
            rtbIAppSericeGenerator.Clear();
            rtbAppSericeGenerator.Clear();
            rtbEntityCreateDtoGenerator.Clear();
            rtbEntityDtoGenerator.Clear();
            rtbEntityUpdateDtoGenerator.Clear();
            rtbIndexJsGenerator.Clear();
            rtbIndexCshtmlGenerator.Clear();
            rtbEntityDtoGenerator.Clear();
            rtbCreateJsGenerator.Clear();
            rtbCreateCsHtmlGenerator.Clear();
            rtbUpdateJsGenerator.Clear();
            rtbUpdateCsHtmlGenerator.Clear();

            rtbAppJsGenerator.Clear();
            rtbAutorizationProviderGenerator.Clear();
            rtbPermissionNameGenerator.Clear();
            rtbNavigationProviderGenerator.Clear();
            rtbMenuNavBarGenerator.Clear();
            Localizations.Clear();
        }

        private void GenerateCsHtmlFiles(List<String> fielListForCreateCsHtml)
        {
            fileNameIndexCsHtml = ViewDirectory + @"\index.cshtml";
            fileNameEditCsHtml = ViewDirectory + @"\editModal.cshtml";
            fileNameCreateCsHtml = ViewDirectory + @"\createModal.cshtml";

            string IndexCsHtmlTemplate = UsingTemplates.CsHtmlCreator.IndexCsHtml;
            IndexCsHtmlTemplate = ReplaceAllKeysWithRealValues(IndexCsHtmlTemplate);
            IndexCsHtmlTemplate += "\n";

            string CreateCsHtmlTemplate = UsingTemplates.CsHtmlCreator.CreateModalCsHtml;
            var strinWithFields = string.Join("", fielListForCreateCsHtml.ToArray());
            CreateCsHtmlTemplate = CreateCsHtmlTemplate.Replace(@"//XXXFieldsHtmlXXX".ToString(), strinWithFields);
            CreateCsHtmlTemplate = ReplaceAllKeysWithRealValues(CreateCsHtmlTemplate);
            CreateCsHtmlTemplate += "\n";


            string UpdateCsHtmlTemplate = UsingTemplates.CsHtmlCreator.EditModalCsHtml;
            UpdateCsHtmlTemplate = UpdateCsHtmlTemplate.Replace(@"//XXXFieldsHtmlXXX".ToString(), strinWithFields);
            UpdateCsHtmlTemplate = ReplaceAllKeysWithRealValues(UpdateCsHtmlTemplate);
            UpdateCsHtmlTemplate += "\n";

            rtbIndexCshtmlGenerator.Clear();
            rtbIndexCshtmlGenerator.AppendText(IndexCsHtmlTemplate);
            rtbUpdateCsHtmlGenerator.Clear();
            rtbUpdateCsHtmlGenerator.AppendText(UpdateCsHtmlTemplate);
            rtbCreateCsHtmlGenerator.Clear();
            rtbCreateCsHtmlGenerator.AppendText(CreateCsHtmlTemplate);
        }

        public String ReplaceAllKeysWithRealValues(String StringTemplate)
        {
            string stringRetorno = StringTemplate;
            stringRetorno = stringRetorno.Replace(XXXEntityPluralXXX, txtCapitalPlural.Text);
            stringRetorno = stringRetorno.Replace(XXXEntityLowerPluralXXX, txtCamelPlural.Text);
            stringRetorno = stringRetorno.Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
            stringRetorno = stringRetorno.Replace(XXXEntityLowerSingularXXX, txtCamelSingular.Text);
            stringRetorno = stringRetorno.Replace(XXXProjectNameXXX, Utils.ProjectName);
            return stringRetorno;
        }

        private void GenerateJsFiles(List<TripleValue<string, string, String, String>> fielList, List<string> fielListForIndexJs, string CallRelatedEntities)
        {
            ViewDirectory = ViewsDirectory + txtCamelPlural.Text;
            fileNameIndexJs = ViewDirectory + @"\index.js";
            fileNameEditJs = ViewDirectory + @"\editModal.js";
            fileNameCreateJs = ViewDirectory + @"\createModal.js";

            string IndexjsTemplate = UsingTemplates.JSCreator.IndexJS;
            var strinWithFields = string.Join("", fielListForIndexJs.ToArray());
            IndexjsTemplate = IndexjsTemplate.Replace(@"//XXXEntityFieldsJSXXX".ToString(), strinWithFields);
            IndexjsTemplate = ReplaceAllKeysWithRealValues(IndexjsTemplate);
            IndexjsTemplate = IndexjsTemplate.Replace(XXXFieldNameCapitalXXX, FielList.First().Value.ToString());
            IndexjsTemplate += "\n";


            String ServiceDeclaration = generateListOfServiceDeclaration(fielList);
            String ServiceSetting = generateListOfServiceSetting(fielList);
            String ServiceCalls = generateListOfServiceCall(fielList);


            string CreateJsTemplate = UsingTemplates.JSCreator.CreateJS;
            CreateJsTemplate = CreateJsTemplate.Replace(@"//XXXInsertCallRelatedEntitiesXXX".ToString(), CallRelatedEntities);
            CreateJsTemplate = ReplaceAllKeysWithRealValues(CreateJsTemplate);
            CreateJsTemplate = CreateJsTemplate.Replace(XXXFieldNameCapitalXXX, FielList.First().Value.ToString());
            CreateJsTemplate = CreateJsTemplate.Replace(XXXServicesUsedDeclarationXXX, ServiceDeclaration);
            CreateJsTemplate = CreateJsTemplate.Replace(XXXServicesUsedSettingXXX, ServiceSetting);
            CreateJsTemplate = CreateJsTemplate.Replace(XXXServiceCallsXXX, ServiceCalls);
            CreateJsTemplate += "\n";


            string EditJsTemplate = UsingTemplates.JSCreator.UpdateJS;
            EditJsTemplate = EditJsTemplate.Replace(@"//XXXInsertCallRelatedEntitiesXXX".ToString(), CallRelatedEntities);
            EditJsTemplate = ReplaceAllKeysWithRealValues(EditJsTemplate);
            EditJsTemplate = EditJsTemplate.Replace(XXXFieldNameCapitalXXX, FielList.First().Value.ToString());
            EditJsTemplate = EditJsTemplate.Replace(XXXServicesUsedDeclarationXXX, ServiceDeclaration);
            EditJsTemplate = EditJsTemplate.Replace(XXXServicesUsedSettingXXX, ServiceSetting);
            EditJsTemplate = EditJsTemplate.Replace(XXXServiceCallsXXX, ServiceCalls);
            EditJsTemplate += "\n";


            rtbIndexJsGenerator.Clear();
            rtbIndexJsGenerator.AppendText(IndexjsTemplate);
            rtbCreateJsGenerator.Clear();
            rtbCreateJsGenerator.AppendText(CreateJsTemplate);
            rtbUpdateJsGenerator.Clear();
            rtbUpdateJsGenerator.AppendText(EditJsTemplate);
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

        public ComboParameter GetComboParameter(String FieldNameValue)
        {
            ComboParameter cp = null;
            foreach (var item in lbxCombos.Items)
            {
                var cpTemp = (ComboParameter)item;

                if (cpTemp.FieldNameValue == FieldNameValue)
                {
                    cp = cpTemp;
                    break;
                }
            }
            return cp;
        }

        private List<string> GenerateFielListForIndexJs(List<TripleValue<string, string, string, String>> fielList, out String RelatedEntities)
        {
            RelatedEntities = "//XXXInsertCallRelatedEntitiesXXX\n\n";
            List<string> fieldListForIndexJs = new List<string>();
            foreach (var item in fielList)
            {


                String newField = "";
                newField += "                    {\n";
                newField += "                    name: App.localize('XXXEntitySingularXXX" + item.Value + "'),\n";
                AddLocalization(txtCapitalSingular.Text + item.Value);
                AddLocalization(item.Value);
                newField += "                    field: '" + item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1) + "',\n";
                newField += "                    minWidth: 125\n";
                newField += "                    },\n";
                fieldListForIndexJs.Add(newField);

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

            return fieldListForIndexJs;
        }

        private List<string> GenerateFielListForCreateCsHtml(List<TripleValue<string, string, string, String>> fielList)
        {
            List<string> fieldListForIndexCsHtml = new List<string>();


            var FieldStringTemplate = UsingTemplates.CsHtmlCreator.FieldString;
            FieldStringTemplate = ReplaceAllKeysWithRealValues(FieldStringTemplate);
            FieldStringTemplate = FieldStringTemplate.Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
            FieldStringTemplate = FieldStringTemplate.Replace(XXXEntityPluralXXX, txtCapitalPlural.Text);
            FieldStringTemplate = FieldStringTemplate.Replace(XXXEntityLowerSingularXXX, txtCamelSingular.Text);
            FieldStringTemplate = FieldStringTemplate.Replace(XXXEntityLowerPluralXXX, txtCamelPlural.Text);
            FieldStringTemplate += "\n";


            var FieldDateTimeTemplate = UsingTemplates.CsHtmlCreator.FieldDatetime;
            FieldDateTimeTemplate = ReplaceAllKeysWithRealValues(FieldDateTimeTemplate);
            FieldDateTimeTemplate += "\n";


            var FieldBooleanTemplate = UsingTemplates.CsHtmlCreator.FieldBoolean;
            FieldBooleanTemplate = ReplaceAllKeysWithRealValues(FieldBooleanTemplate);
            FieldBooleanTemplate += "\n";
            //FieldStringTemplate = FieldStringTemplate.Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
            //FieldStringTemplate = FieldStringTemplate.Replace(XXXEntityPluralXXX, txtCapitalPlural.Text);
            //FieldStringTemplate = FieldStringTemplate.Replace(XXXEntityLowerSingularXXX, txtCamelSingular.Text);
            //FieldStringTemplate = FieldStringTemplate.Replace(XXXEntityLowerPluralXXX, txtCamelPlural.Text);
            //FieldStringTemplate += "\n";

            var FieldNumberTemplate = UsingTemplates.CsHtmlCreator.FieldNumber;
            FieldNumberTemplate = FieldNumberTemplate.Replace(XXXEntitySingularXXX, txtCapitalSingular.Text);
            FieldNumberTemplate = FieldNumberTemplate.Replace(XXXEntityPluralXXX, txtCapitalPlural.Text);
            FieldNumberTemplate = FieldNumberTemplate.Replace(XXXEntityLowerSingularXXX, txtCamelSingular.Text);
            FieldNumberTemplate = FieldNumberTemplate.Replace(XXXEntityLowerPluralXXX, txtCamelPlural.Text);
            FieldNumberTemplate += "\n";

            var FieldRelatedTemplate = UsingTemplates.CsHtmlCreator.FieldRelated;
            FieldRelatedTemplate = ReplaceAllKeysWithRealValues(FieldRelatedTemplate);
            FieldNumberTemplate += "\n";


            foreach (var item in fielList)
            {
                AddLocalization(txtCapitalSingular.Text + item.Value);
                string isRequired = "required";
                string nameCamel = item.Value.Substring(0, 1).ToLower() + item.Value.Substring(1);
                String newField = "";

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
                        newField = FieldNumberTemplate.Replace(XXXFieldNameCamelXXX, nameCamel);

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
            return fieldListForIndexCsHtml;
        }

        public static string fileNameEntityDto = "ListDto.cs";
        public static string fileNameCreateDto = "CreateDto.cs";
        public static string fileNameUpdateDto = "UpdateDto.cs";

        private List<TripleValue<String, String, String, String>> GenerateDtos(string[] loadedClass)
        {
            List<TripleValue<String, String, String, String>> fieldList = new List<TripleValue<string, string, string, String>>();
            DtosPathTemp = DtosPath + txtCapitalPlural.Text + @"\Dto\";

            fileNameEntityDto = DtosPathTemp + txtCapitalPlural.Text + "Dto.cs";
            fileNameCreateDto = DtosPathTemp + txtCapitalPlural.Text + "CreateDto.cs";
            fileNameUpdateDto = DtosPathTemp + txtCapitalPlural.Text + "UpdateDto.cs";

            List<string> allowedtypes = new List<string>() { "int", "string", "String","Integer","DateTime","Date","Decimal","decimal","float","double","Double","long","int32",
                "int16","int64","bool","Boolean" };

            string classListDto = DtosCreator.EntityDto_JustStartLines;

            classListDto = ReplaceAllKeysWithRealValues(classListDto);
            classListDto += "\n";


            string classUpdateDto = DtosCreator.UpdateDto_JustStartLines;
            classUpdateDto = ReplaceAllKeysWithRealValues(classUpdateDto);
            classUpdateDto += "\n";


            string classCreateDto = DtosCreator.CreateDto_JustStartLines;
            classCreateDto = ReplaceAllKeysWithRealValues(classCreateDto);
            classCreateDto += "\n";


            classListDto += "              public int Id {get;set;} \n";

            for (int i = 0; i < loadedClass.Length; i++)
            {
                var lineX = loadedClass[i].Replace("  ", " ");
                if (!lineX.Contains("public"))
                    continue;

                if (lineX.Contains("class"))
                    continue;

                if (lineX.Contains("("))
                    continue;



                var type = GetTypeString(lineX);
                var property = GetPropertyString(lineX);


                if (!allowedtypes.Contains(type.Replace("?", "")))
                    continue;
                string lineXAnterior = loadedClass[i - 1]; ;
                string maxLenghtX = frmPrincipal.GetMaxLengString(lineXAnterior);
                string MaxLentJustInt = frmPrincipal.GetMaxLengIntForString(lineXAnterior);

                var field = new TripleValue<string, string, string, String>(type, property, maxLenghtX, MaxLentJustInt);
                fieldList.Add(field);
                classListDto += "              public " + type + " " + property + " {get;set;} \n";

                classUpdateDto += (!string.IsNullOrEmpty(field.ValueAlt) ? "\n              [StringLength(" + field.ValueAlt + ")]  " : "")
                + "\n              public " + type + " " + property + " {get;set;} \n";

                classCreateDto += (!string.IsNullOrEmpty(field.ValueAlt) ? "\n              [StringLength(" + field.ValueAlt + ")] " : "")
                    + "\n              public " + type + " " + property + " {get;set;} \n";
            }

            classListDto += "              public bool IsActive {get;set;} \n";
            classListDto += "              public DateTime CreationTime {get;set;} \n";
            classListDto += "              public long? CreatorUserId {get;set;} \n";


            classCreateDto += "              public bool IsActive {get;set;} \n";
            classCreateDto += "              public DateTime CreationTime {get;set;} \n";
            classCreateDto += "              public long? CreatorUserId {get;set;} \n";


            classUpdateDto += "              public bool IsActive {get;set;} \n";
            classUpdateDto += "              public DateTime CreationTime {get;set;} \n";
            classUpdateDto += "              public long? CreatorUserId {get;set;} \n";

            classListDto += "\n         }\n}";
            classUpdateDto += "\n         }\n}";
            classCreateDto += "\n         }\n}";


            classCreateDto = ReplaceAllKeyTypes(classCreateDto);
            classUpdateDto = ReplaceAllKeyTypes(classUpdateDto);
            classListDto = ReplaceAllKeyTypes(classListDto);


            rtbEntityDtoGenerator.Clear();
            rtbEntityDtoGenerator.AppendText(classListDto);
            rtbEntityUpdateDtoGenerator.Clear();
            rtbEntityUpdateDtoGenerator.AppendText(classUpdateDto);
            rtbEntityCreateDtoGenerator.Clear();
            rtbEntityCreateDtoGenerator.AppendText(classCreateDto);

            return fieldList;
        }

        public static string GetTypeString(String Line)
        {
            string currentType = "";

            var index = Line.IndexOf("public");
            var indexType = Line.IndexOf(" ", index + 1);
            var indexProperty = Line.IndexOf(" ", indexType + 1);
            currentType = Line.Substring(indexType + 1, indexProperty - indexType - 1);
            return currentType;
        }

        public static string GetPropertyString(String Line)
        {
            string property = "";

            var index = Line.IndexOf("public");
            var indexType = Line.IndexOf(" ", index + 1);
            var indexProperty = Line.IndexOf(" ", indexType + 1);
            var indexPropertyEnd = Line.IndexOf(" ", indexProperty + 1);
            property = Line.Substring(indexProperty + 1, indexPropertyEnd - indexProperty - 1).Replace('}', ' ').Replace('{', ' ').TrimEnd();
            return property;
        }


        private void btnSaveOnDisk_Click(object sender, EventArgs e)
        {
            btnSaveOnDisk.Visible = false;
            try
            {
                string PathDirectoryAppService = pathDirectoryApp + txtCapitalPlural.Text;
                if (!System.IO.Directory.Exists(PathDirectoryAppService))
                    System.IO.Directory.CreateDirectory(PathDirectoryAppService);

                if (!System.IO.Directory.Exists(DtosPathTemp))
                    System.IO.Directory.CreateDirectory(DtosPathTemp);

                if (!System.IO.Directory.Exists(ViewDirectory))
                    System.IO.Directory.CreateDirectory(ViewDirectory);

                string fileNameIAppService = PathDirectoryAppService + @"\I" + txtCapitalSingular.Text + "AppService.cs";
                string fileNameAppService = PathDirectoryAppService + @"\" + txtCapitalSingular.Text + "AppService.cs";

                //Se genera el archivo de la Interface
                createSpecificFileOnDisk(fileNameIAppService, rtbIAppSericeGenerator);

                //Se general el archivo del servicio
                createSpecificFileOnDisk(fileNameAppService, rtbAppSericeGenerator);

                createSpecificFileOnDisk(fileNameEntityDto, rtbEntityDtoGenerator);
                createSpecificFileOnDisk(fileNameCreateDto, rtbEntityCreateDtoGenerator);
                createSpecificFileOnDisk(fileNameUpdateDto, rtbEntityUpdateDtoGenerator);

                createSpecificFileOnDisk(fileNameIndexJs, rtbIndexJsGenerator);
                createSpecificFileOnDisk(fileNameCreateJs, rtbCreateJsGenerator);
                createSpecificFileOnDisk(fileNameEditJs, rtbUpdateJsGenerator);

                createSpecificFileOnDisk(fileNameIndexCsHtml, rtbIndexCshtmlGenerator);
                createSpecificFileOnDisk(fileNameEditCsHtml, rtbUpdateCsHtmlGenerator);
                createSpecificFileOnDisk(fileNameCreateCsHtml, rtbCreateCsHtmlGenerator);


                createSpecificFileOnDisk(frmPrincipal.AuthorizationProviderFile, rtbAutorizationProviderGenerator);
                createSpecificFileOnDisk(frmPrincipal.NavigationProviderFile, rtbNavigationProviderGenerator);
                createSpecificFileOnDisk(frmPrincipal.PermissionNamesFile, rtbPermissionNameGenerator);
                createSpecificFileOnDisk(frmPrincipal.AppJsFile, rtbAppJsGenerator);
                createSpecificFileOnDisk(frmPrincipal.NavBarJSFile, rtbMenuNavBarGenerator);

                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("Mantenimiento generado exitosamente");
            }
            catch (Exception err)
            {
                MessageBox.Show("Surgió el siguiente error : " + err.Message);
            }
            Application.Exit();

        }

        private void createSpecificFileOnDisk(string fileName, RichTextBox textContainer)
        {
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            System.IO.File.AppendAllText(fileName, textContainer.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utils.ProjectName = ConfigurationManager.AppSettings["ProjectName"].ToString();
            Utils.SideBarFileName = ConfigurationManager.AppSettings["SideBarFileName"].ToString();
            txtProjectName.Text = Utils.ProjectName;
            Utils.ReadAllTemplastes();
            Utils.ReadAllOriginal();
            lbxCombos.Items.Clear();
            this.Text = Utils.Version;
            txtCamelSingular.Focus();
        }

        private void RichTextBoxGeneral_MouseClick(object sender, MouseEventArgs e)
        {
            frmVisor vs = new frmVisor((RichTextBox)sender);
            vs.ShowDialog();
        }

        public static int getDaysElapsedBetweenDateRange(DateTime CurrentDate, DateTime OriginDate)
        {
            int elapsedDays = 0;
            TimeSpan ts = CurrentDate - OriginDate;

            elapsedDays = ts.Days;

            return elapsedDays;
        }


        private void btnAgregarCombo_Click(object sender, EventArgs e)
        {

            if (txtRelateFieldDisplay.BackColor == Color.Red)
                return;
            if (txtRelateFieldValue.BackColor == Color.Red)
                return;
            if (txtRelateEntity.BackColor == Color.Red)
                return;

            if (string.IsNullOrEmpty(txtRelateEntity.Text) ||
                string.IsNullOrEmpty(txtRelateFieldDisplay.Text) ||
                string.IsNullOrEmpty(txtRelateFieldValue.Text))
            {
                MessageBox.Show("Debe completar todos los campos de la entidad relacionda");
                return;
            }

            ComboParameter cbp = new ComboParameter(txtRelateEntity.Text, txtRelateFieldValue.Text, txtRelateFieldDisplay.Text);
            lbxCombos.Items.Add(cbp);

            txtRelateEntity.Clear();
            txtRelateFieldDisplay.Clear();
            txtRelateFieldValue.Clear();
            btnGenerate_Click(null, null);
        }

        private void txtRelateFieldValue_TextChanged(object sender, EventArgs e)
        {
            txtRelateFieldValue.BackColor = Color.White;
            if (txtRelateFieldValue.Text.Length == 0)
                return;


            if (ExistInFielList(txtRelateFieldValue.Text))
            {
                txtRelateFieldValue.BackColor = Color.Green;
                btnAgregarCombo.Enabled = true;
            }
            else
                if (!ExistInFielList(txtRelateFieldValue.Text))
            {
                txtRelateFieldValue.BackColor = Color.Red;
                btnAgregarCombo.Enabled = false;
            }
        }

        public List<TripleValue<string, string, string, String>> fieldsRelatedEntity = new List<TripleValue<string, string, string, String>>();


        private void txtRelateEntity_TextChanged(object sender, EventArgs e)
        {
            txtRelateEntity.BackColor = Color.White;
            if (txtRelateEntity.Text.Length == 0)
                return;

            fieldsRelatedEntity = Utils.getFieldListFromEntity(txtRelateEntity.Text);
            if (fieldsRelatedEntity.Count == 0)
                txtRelateEntity.BackColor = Color.Red;
            else
                txtRelateEntity.BackColor = Color.Green;
        }

        private void txtRelateFieldDisplay_TextChanged(object sender, EventArgs e)
        {
            txtRelateFieldDisplay.BackColor = Color.White;
            if (txtRelateFieldDisplay.Text.Length == 0)
                return;


            if (ExistInRelatedFielList(txtRelateFieldDisplay.Text))
            {
                txtRelateFieldDisplay.BackColor = Color.Green;
                btnAgregarCombo.Enabled = true;
            }
            else
                    if (!ExistInRelatedFielList(txtRelateFieldDisplay.Text))
            {
                txtRelateFieldDisplay.BackColor = Color.Red;
                btnAgregarCombo.Enabled = false;
            }
        }

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            txtCamelSingular.Focus();
        }
    }
}
