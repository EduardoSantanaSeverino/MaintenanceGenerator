namespace MG.Application.Generic
{
    public class ItemConfig
    {
        public ItemConfig()
        {
            
        }

        public ItemConfig(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public ItemConfig(string name, string value, bool isPath)
        {
            Name = name;
            Value = value;
            IsPath = isPath;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool CreateDirectory { get; set; }
        public bool IsChecked { get; set; }
        public bool IsPath { get; set; }
    }
}
