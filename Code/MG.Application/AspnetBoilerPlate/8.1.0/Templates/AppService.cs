using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using XXXProjectNameXXX.Authorization;
using XXXProjectNameXXX.XXXEntityPluralXXX.Dto;
using XXXProjectNameXXX.Models;

namespace XXXProjectNameXXX.XXXEntityPluralXXX
{

    [AbpAuthorize(PermissionNames.Pages_XXXEntityPluralXXX)]
    public class XXXEntitySingularXXXAppService : AsyncCrudAppService<XXXEntitySingularXXX, XXXEntitySingularXXXDto, XXXSpecificTypeXXX, PagedXXXEntitySingularXXXResultRequestDto, CreateXXXEntitySingularXXXDto, UpdateXXXEntitySingularXXXDto>, IXXXEntitySingularXXXAppService
    {
        public XXXEntitySingularXXXAppService
        (
            IRepository<XXXEntitySingularXXX, XXXSpecificTypeXXX> repository
        )
        : base(repository)
        {
           
        }

    }
}

