namespace MG.Application.Generic
{
    public class ItemFieldTypeTemplate 
    {
        public ItemFieldTypeTemplate()
        {
            this.ForFields = true;
            this.TemplateDirectory = "MGTemplates/";
        }
        private string TemplateDirectory { get; set; }
        private string _templateName { get; set; }

        public ItemFieldTypeTemplate(string TemplateDirectory)
        {
            this.TemplateDirectory = TemplateDirectory;
            this.ForFields = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TemplateName
        {
            get { return _templateName; }
            set { _templateName = value; ReadTemplate(); }
        }
        public string TemplateMarkup { get; set; }

        public void ReadTemplate()
        {
            try
            {
                TemplateMarkup = System.IO.File.ReadAllText(TemplateDirectory + _templateName);
            }
            catch (Exception err)
            { }
        }

        public bool ForFields { get; set; }
    }
}