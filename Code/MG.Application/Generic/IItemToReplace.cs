namespace MG.Application.Generic
{
    public interface IItemToReplace
    {
         int Id { get; set; }
         string Key { get; set; }
         string Value { get; set; }
         string LabelText { get; set; }
    }
}
