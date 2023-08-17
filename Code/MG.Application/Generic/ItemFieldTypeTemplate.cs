namespace MG.Application.Generic
{
    public class ItemFieldTypeTemplate 
    {
      
        public ItemFieldTypeTemplate(string templateDirectory)
        {
            this.ForFields = true;
            this.TemplateDirectory = templateDirectory;
        }
        
        private string TemplateDirectory { get; set; }
        private string _templateName { get; set; }
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
                if (this.TemplateName.Contains("sidebar-menu.component.ts.place1"))
                {
                    var t = "";
                }
                TemplateMarkup = System.IO.File.ReadAllText(TemplateDirectory + _templateName);
            }
            catch (Exception err)
            { }
        }

        public bool ForFields { get; set; }
    }
}
