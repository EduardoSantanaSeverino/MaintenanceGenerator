using MG.Application.Generic;

namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public class ItemFilePlaceHolderList : IItemFilePlaceHolderList
{
    private Dictionary<string, IPlaceHolderItem> items = new Dictionary<string, IPlaceHolderItem>();
    
    public ItemFilePlaceHolderList()
    {
        List<IPlaceHolderItem> _placeHolderItems = new List<IPlaceHolderItem>();

        _placeHolderItems.Add(new PlaceHolderItem_Import_TS("///app.module.ts.place1///"));
        _placeHolderItems.Add(new PlaceHolderItem_SquaredBrakets("///app.module.ts.place2///","declarations:["));

        _placeHolderItems.Add(new PlaceHolderItem_Import_TS("///app-routing.module.ts.place1///"));
        _placeHolderItems.Add(new PlaceHolderItem_SquaredBrakets("///app-routing.module.ts.place2///","children:["));
        
        _placeHolderItems.Add(new PlaceHolderItem_CurlyBrakets("///AuthorizationProvider.cs.place1///", "public override void SetPermissions(IPermissionDefinitionContext context)"));
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

