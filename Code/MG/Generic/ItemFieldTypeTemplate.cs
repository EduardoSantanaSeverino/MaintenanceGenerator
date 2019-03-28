using System;

namespace MG.Generic
{
    public class ItemFieldTypeTemplate 
    {
        private string TemplateDirectory { get; set; }
        private string _templateName { get; set; }

        public ItemFieldTypeTemplate(string TemplateDirectory)
        {
            this.TemplateDirectory = TemplateDirectory;
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
    }
}