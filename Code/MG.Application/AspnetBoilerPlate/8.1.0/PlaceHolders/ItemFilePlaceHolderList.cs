using MG.Application.Generic;

namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public class ItemFilePlaceHolderList : IItemFilePlaceHolderList
{
    private Dictionary<string, IPlaceHolderItem> items = new Dictionary<string, IPlaceHolderItem>();
    
    public ItemFilePlaceHolderList()
    {
        List<IPlaceHolderItem> _placeHolderItems = new List<IPlaceHolderItem>();

        _placeHolderItems.Add(new PlaceHolderItem_app_module_ts_place1());
        _placeHolderItems.Add(new PlaceHolderItem_app_module_ts_place2());
        // _placeHolderItems.Add(new PlaceHolderItem_app_module_ts_place3());
        
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
    
}

