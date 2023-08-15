using System.Globalization;

namespace MG.Application.Generic;

public class ItemFilePlaceHolderList
{
    private Dictionary<string, IPlaceHolderItem> items = new Dictionary<string, IPlaceHolderItem>();
    
    public ItemFilePlaceHolderList()
    {
        List<IPlaceHolderItem> _placeHolderItems = new List<IPlaceHolderItem>();

        _placeHolderItems.Add(new PlaceHolderItem_app_module_ts_place1());
        
        foreach (var item in _placeHolderItems)
        {
            items.Add(item.Name,item);
        }
    }

    public IPlaceHolderItem GetItem(string name)
    {
        IPlaceHolderItem retVal;
        items.TryGetValue(name, out retVal);
        return retVal;
    }
    
    public class PlaceHolderItem_app_module_ts_place1 : IPlaceHolderItem
    {
        
        public PlaceHolderItem_app_module_ts_place1()
        {
            this.Name = "///app.module.ts.place1///";
        }
        public string Name { get; }

        public virtual bool IsImportLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }
            return line.ToLower().Trim().Replace(" ", "").StartsWith("import{");
        }

        public virtual bool IsSpaceLine(string line)
        {
            return string.IsNullOrWhiteSpace(line);
        }
        
        public virtual bool IsCommentLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }
            return line.ToLower().Trim().Replace(" ", "").StartsWith("//");
        }

        public string Process(string fileContent)
        {

            // Split the content into lines
            string[] lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int lastImportIndex = 0;
            
            for (int index = 0; index < lines.Length; index++)
            {
                // Process each line here
                var line = lines[index];
                if (this.IsImportLine(line))
                {
                    lastImportIndex = index;
                }

                if (!this.IsImportLine(line) && !this.IsCommentLine(line) && !this.IsSpaceLine(line))
                {
                    lines[lastImportIndex] += Environment.NewLine + this.Name;
                    break;
                }
            }
           
            // Convert lines array back to fileContent string
            return string.Join(Environment.NewLine, lines);;
        }
    }
    
    public interface IPlaceHolderItem
    {
        string Name { get; }
        string Process(string fileContent);
    }
}

