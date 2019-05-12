using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using XXXProjectNameXXX.XXXEntityPluralXXX.Dto;
using XXXProjectNameXXX.Models;

namespace XXXProjectNameXXX.XXXEntityPluralXXX
{

    [AbpAuthorize]
    public class XXXEntitySingularXXXAppService : XXXProjectNameXXXCrudAppServiceBase<XXXEntitySingularXXX, XXXEntitySingularXXXDto, int, PagedModelsResultRequestDto, XXXEntitySingularXXXCreateDto, XXXEntitySingularXXXUpdateDto>, IXXXEntitySingularXXXAppService
    {
        public XXXEntitySingularXXXAppService
        (
            IRepository<XXXEntitySingularXXX> repository
        )
        : base(repository)
        {
           
        }

    }
}

