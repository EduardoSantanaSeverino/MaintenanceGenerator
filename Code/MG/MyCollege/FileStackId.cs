using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public enum FileStackId
    {
        IndexCsHtmlTemplate,
        CreateModalCsHtmlTemplate,
        UpdateCsHtmlTemplate,
        IndexJSTemplate,
        CreateJSTemplate,
        UpdateJSTemplate,
        DtoTemplate,
        UpdateDtoTemplate, // = ReadTemplate("UpdateDto.tpt");
        CreateDtoTemplate, // = ReadTemplate("CreateDto.tpt");
        IAppServiceTemplate, // = ReadTemplate("IAppService.tpt");
        AppServiceTemplate, // = ReadTemplate("AppService.tpt");
        AuthorizationProviderTemplate, // = ReadTemplate("AuthorizationProvider.tpt");
        PermissionNameTemplate, //= ReadTemplate("PermissionName.tpt");
        AppJsMenuTemplate, //= ReadTemplate("AppJsMenu.tpt");
        NavigationProviderTemplate, //= ReadTemplate("NavigationProvider.tpt");
        MenuSideBarNavTemplate //= ReadTemplate("MenuSideBarNav.tpt");
    }
    
}
