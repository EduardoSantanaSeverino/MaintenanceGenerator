namespace MG.Application.Generic
{
    public class AttributeProperty
    {
        public string Description { get; set; } = string.Empty;
        public bool ShowOnList { get; set; }
        public bool ShowOnCreate { get; set; }
        public bool ShowOnUpdate { get; set; }
        public bool Hidden { get; set; }
    }
}
