namespace MG.Application.Generic
{
    public abstract class CrudGeneratorBase : ICrudGenerator
    {
        public IClassInfoData ClassInfoData { get; protected set; }
        public IConfiguration Configuration { get; protected set; }
        public string Version { get; protected set; }
        public string TemplateDirectory { get; protected set; }
        public string ProjectName { get; protected set; }
        public List<IItemFileToGenerate> ItemFileToGenerates { get; set; }
        public CrudGeneratorBase(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.Version = configuration.GetConfig("Version");
            this.TemplateDirectory = configuration.GetConfig("TemplateDirectory");
            this.ProjectName = configuration.GetConfig("ProjectName");
            this.Initialize();
        }
        public void btnSaveOnDisk_Click()
        {
            foreach (var item in this.ItemFileToGenerates)
            {
                CreateDirectoryIfNotExist(item.Path);
                createSpecificFileOnDisk(item.Path, item.TemplateMarkup);
            }
            System.Threading.Thread.Sleep(1000);
        }

        public virtual void Initialize()
        {
            var itemToReplaces = this.Configuration.GetItemToReplaces();
            string entitySingular = itemToReplaces.FirstOrDefault(p => p.Key == "XXXEntitySingularXXX")?.Value;
            //string entityPlural = ItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntityPluralXXX")?.Value;

            this.ClassInfoData = new ClassInfoDataBase(Configuration.GetConfig("ClassesPath"), entitySingular + ".cs", itemToReplaces);
            Configuration.AddConfig(new List<ItemConfig> {
                new ItemConfig
                {
                    Name = "ClassPath",
                    Value = Configuration.GetConfig("ClassesPath") + this.ClassInfoData.XXXEntitySingularXXX + ".cs",
                    IsPath = true
                }
            });

            LoadItemFileToCreate();
            
        }

        protected abstract void LoadItemFileToCreate();

        protected void createSpecificFileOnDisk(string fileName, string containerText)
        {
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            System.IO.File.AppendAllText(fileName, containerText);
        }

        public virtual void AddComboParameter(ComboParameter comboParameter)
        {
            this.ClassInfoData.AddComboParameter(comboParameter);
            LoadItemFileToCreate();
        }

        private void CreateDirectoryIfNotExist(string filePath)
        {
            var str = new string[] { @"\" };
            var l = filePath.Split(str,StringSplitOptions.None);
            var last = l.Last();
            var s = filePath.Replace(last, "");
            if (!System.IO.Directory.Exists(s))
            {
                System.IO.Directory.CreateDirectory(s);
            }
        }
    }
}
