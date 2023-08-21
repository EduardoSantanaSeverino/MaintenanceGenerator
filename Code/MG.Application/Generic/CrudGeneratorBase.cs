namespace MG.Application.Generic
{
    public abstract class CrudGeneratorBase : ICrudGenerator
    {
        public IClassInfoData ClassInfoData { get; protected set; }
        public IConfiguration Configuration { get; protected set; }
        public IItemFilePlaceHolderList ItemFilePlaceHolderList { get; }
        public string Version { get; protected set; }
        public string TemplateDirectory { get; protected set; }
        public string ProjectName { get; protected set; }
        public List<IItemFileToGenerate> ItemFileToGenerates { get; set; }
        public CrudGeneratorBase(IConfiguration configuration, IItemFilePlaceHolderList itemFilePlaceHolderList)
        {
            this.ItemFilePlaceHolderList = itemFilePlaceHolderList;
            this.Configuration = configuration;
            this.Version = configuration.GetConfig("XXXVersionXXX");
            this.TemplateDirectory = configuration.GetConfig("XXXTemplateDirectoryXXX");
            this.ProjectName = configuration.GetConfig("XXXProjectNameXXX");
            this.Initialize();
        }
        
        public void SaveOnToDisk()
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
            var itemToReplaces = this.Configuration.ItemConfigs;
            string entitySingular = itemToReplaces.FirstOrDefault(p => p.Name == "XXXEntitySingularXXX")?.Value;
            //string entityPlural = ItemToReplaces.FirstOrDefault(p => p.Key == "XXXEntityPluralXXX")?.Value;

            this.ClassInfoData = new ClassInfoDataBase(Configuration.GetConfig("ClassesPath"), entitySingular + ".cs", itemToReplaces, null, this.ItemFilePlaceHolderList);
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
            var s = System.IO.Path.GetDirectoryName(filePath);
            if (!System.IO.Directory.Exists(s))
            {
                System.IO.Directory.CreateDirectory(s);
            }
        }
    }
}
