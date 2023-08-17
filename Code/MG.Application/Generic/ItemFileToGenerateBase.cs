namespace MG.Application.Generic
{
    public abstract class ItemFileToGenerateBase : IItemFileToGenerate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string TemplateName { get; set; }
        public string TemplateMarkup { get; set; }
        public string TemplateDirectory { get; set; }
        public string SourceTemplateDirectory { get; set; }
        public IClassInfoData ClassInfoData { get; set; }
        public string ControlName { get; set; }
        public List<ItemFieldTypeTemplate> ItemFieldTypeTemplates { get; set; }
        public string FileType { get; set; }

        public ItemFileToGenerateBase
        (
            int Id,
            string Name,
            string Path,
            string TemplateName,
            string TemplateDirectory,
            IClassInfoData ClassInfoData,
            List<ItemFieldTypeTemplate> ItemFieldTypeTemplates,
            string FileType,
            string SourceTemplateDirectory
        )
        {
            
            this.FileType = FileType;
            this.Id = Id;
            this.Name = Name;
            this.ControlName = "rtb" + this.Name;
            this.Path = Path;
            this.TemplateName = TemplateName;
            this.TemplateDirectory = TemplateDirectory;
            this.SourceTemplateDirectory = SourceTemplateDirectory;
            this.ItemFieldTypeTemplates = ItemFieldTypeTemplates;
            this.ClassInfoData = ClassInfoData;
            this.Path = this?.Path?.Replace('\\', System.IO.Path.DirectorySeparatorChar);
            this.TemplateDirectory = this?.TemplateDirectory?.Replace('\\', System.IO.Path.DirectorySeparatorChar);
           
            if (this.Name == "sidebar_menu_component_ts")
            {
                var tem = "";
            }
            this.TemplateMarkup = ReadTemplate();
         
            if (string.IsNullOrEmpty(this.FileType))
            {
                this.FileType = FileTypes.Others.ToString();
            }

            try
            {
                this.TemplateMarkup = ProcessGenericFields(this.TemplateMarkup);
            }
            catch (Exception ex)
            {
            }

            this.TemplateMarkup = ReplaceAllKeysWithRealValues(this.TemplateMarkup);
            
        }

        protected string GetFieldTypeTemplate(string name)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Name == name)?.TemplateMarkup;
        }

        protected string GetFieldTypeTemplate(int id)
        {
            return this.ItemFieldTypeTemplates?.FirstOrDefault(p => p.Id == id)?.TemplateMarkup;
        }

        protected string ReadTemplate()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.TemplateDirectory) && !string.IsNullOrEmpty(this.TemplateName))
                {
                    var str = System.IO.File.ReadAllText(this.TemplateDirectory + this.TemplateName);

                    if (!string.IsNullOrEmpty(str))
                    {
                        // TODO: probably grab a file and do replace its content.
                        // if (this.ClassInfoData.ItemFilePlaceHolderList.GetItem($"{this.Id}") != null)
                        // {
                        //     var placeHolderItem = this.ClassInfoData.ItemFilePlaceHolderList.GetItem($"{this.Id}");
                        //     str = placeHolderItem.Process(str);
                        // }
                        str = FillFieldsAndPlaces(str, this.TemplateName);
                    }
                    return str;
                }
            }
            catch (Exception err)
            { }
            return "";
        }

        private string FillFieldsAndPlaces(string fileContent, string templateName)
        {
            var fileExtention = templateName.Split('.').Last();

            var separator1 = "///";
            var separator2 = "///";

            if (fileExtention.ToLower() == "html")
            {
                separator1 = "<!--";
                separator2 = "-->";
            }

            var typeOfSpaceHolders = new List<string>() { "fields", "place" };
            foreach (var spaceHolder in typeOfSpaceHolders)
            {
                
                for (int i = 1; i < 10; i++)
                {
                    var existSubFile = $"{separator1}{templateName}.{spaceHolder}{i}{separator2}";

                    if (!fileContent.Contains(existSubFile) && this.ClassInfoData.ItemFilePlaceHolderList.GetItem(existSubFile) != null)
                    {
                        var placeHolderItem = this.ClassInfoData.ItemFilePlaceHolderList.GetItem(existSubFile);
                        fileContent = placeHolderItem.Process(fileContent);
                    }
                    if (this.ItemFieldTypeTemplates == null)
                    {
                        this.ItemFieldTypeTemplates = new List<ItemFieldTypeTemplate>();
                    }
                    if (fileContent.Contains(existSubFile) && !this.ItemFieldTypeTemplates.Any(p => p.Name == existSubFile))
                    {
                        this.ItemFieldTypeTemplates.Add(new ItemFieldTypeTemplate(this.SourceTemplateDirectory)
                        {
                            ForFields = ("fields" == spaceHolder),
                            Name = existSubFile,
                            TemplateName = existSubFile
                                .Replace(separator1, "")
                                .Replace(separator2, "") + "." + 
                                fileExtention
                        });
                    }
                }
            }

            foreach (var item in this.ItemFieldTypeTemplates)
            {
                if (!fileContent.Contains(item.Name) && this.ClassInfoData.ItemFilePlaceHolderList.GetItem(item.Name) != null)
                {
                    var placeHolderItem = this.ClassInfoData.ItemFilePlaceHolderList.GetItem(item.Name);
                    fileContent = placeHolderItem.Process(fileContent);
                }
            }
            
            return fileContent;
        }

        // private string AddTemplateHolder(string fileContent, string placeHolderItemName)
        // {
        //     var placeHolderItem = this.ClassInfoData.ItemFilePlaceHolderList.GetItem(placeHolderItemName);
        //     if (placeHolderItem != null)
        //     {
        //         fileContent = placeHolderItem.Process(fileContent);
        //     }
        //     return fileContent;
        // }

        protected string GetItemToReplaces(string key)
        {
            return ClassInfoData?.ItemToReplaces?.FirstOrDefault(p => p.Key == key)?.Value;
        }

        protected string ReplaceAllKeysWithRealValues(string markup)
        {
            if (!string.IsNullOrEmpty(markup))
            {
                foreach (var item in ClassInfoData?.ItemToReplaces)
                {
                    markup = markup.Replace(item.Key, item.Value);
                }

                markup += "\n";
            }

            return markup;
        }

        protected ComboParameter GetComboParameter(string FieldNameValue)
        {
            return this.ClassInfoData?.ComboParameters?.FirstOrDefault(p => p.FieldNameValue == FieldNameValue);
        }

        protected string ProcessGenericFields(string markup)
        {
            foreach (var item in this.ItemFieldTypeTemplates)
            {
                // if (this.Name == "AuthorizationProvider_cs")
                // {
                //     var asdf = 0;
                // }
                if (item.ForFields)
                {
                    markup = markup.Replace(item.Name, ProcessField(item) + "\n" + item.Name);
                }
                else
                {
                    markup = markup.Replace(item.Name, item.TemplateMarkup + "\n" + item.Name);
                }
                
            }
            return markup;
        }

        protected string ProcessField(ItemFieldTypeTemplate itemField)
        {
            string[] stringSeparators = new string[] { "{|}" };
            string[] array = itemField.TemplateMarkup.Split( stringSeparators, StringSplitOptions.None );
            bool isMultiType = ((array.Length > 1) && itemField.TemplateMarkup.Contains("default"));

            var l = new List<string>();
            foreach (var item in this.ClassInfoData.Fields)
            {
                if (item.ShowOnList.Any() && !string.IsNullOrEmpty(this.FileType))
                {
                    if (item.ShowOnList.Any(p => p.Replace("ShowOn","") == this.FileType) || this.FileType == FileTypes.Others.ToString())
                    {
                        ProcessFieldItem(itemField, array, isMultiType, l, item);
                    }
                }
                else
                {
                    ProcessFieldItem(itemField, array, isMultiType, l, item);
                }
               
            }
            return string.Join("\n", l.ToArray());
        }

        private void ProcessFieldItem(ItemFieldTypeTemplate itemField, 
            string[] array, 
            bool isMultiType, 
            List<string> l, 
            TripleValue<string, string, string, string> item)
        {
            string n = "";

            
            if (isMultiType)
            {
                bool isFound = false;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == item.Type)
                    {
                        isFound = true;
                        n = array[i + 1];
                    }
                }
                if (!isFound)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == "default")
                        {
                            n = array[i + 1];
                        }
                    }
                }
            }
            else
            {
                n = itemField.TemplateMarkup;
            }

            if (!string.IsNullOrEmpty(n))
            {
                n = n.Replace("XXXFieldNameXXX", item.Name);
                n = n.Replace("XXXFieldNameLowerXXX", item.Name.ToLower());
                n = n.Replace("XXXFieldTypeXXX", item.Type);
                n = n.Replace("XXXFieldMaxLenghtXXX", item.MaxLenght);
                n = n.Replace("XXXFieldMaxLenghtIntXXX", item.MaxLenghtJustInt);
                l.Add(n);
            }
        }
    }
}
