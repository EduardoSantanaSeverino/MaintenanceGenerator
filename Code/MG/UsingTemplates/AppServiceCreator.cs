using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG
{
    class AppServiceCreator
    {
        public static string TemplateAppService =
            "using System.Linq; \n" +
"using System.Threading.Tasks; \n" +
"using Abp.Application.Services; \n" +
"using Abp.Application.Services.Dto; \n" +
"using Abp.Authorization; \n" +
"using Abp.Domain.Repositories; \n" +
"using Abp.IdentityFramework; \n" +
"using GEDUCON.Authorization; \n" +
"using Microsoft.AspNet.Identity; \n" +
"using GEDUCON.XXXEntityPluralXXX.Dto; \n" +
"using System.Collections.Generic; \n" +
"using GEDUCON.GD; \n\n \n" +
"namespace GEDUCON.XXXEntityPluralXXX \n" +
"{ \n" +
"    [AbpAuthorize(PermissionNames.Pages_XXXEntityPluralXXX)] \n" +
"    public class XXXEntitySingularXXXAppService : AsyncCrudAppService<Models.XXXEntityPluralXXX, XXXEntitySingularXXXDto, int, PagedResultRequestDto, CreateXXXEntitySingularXXXDto, UpdateXXXEntitySingularXXXDto>, IXXXEntitySingularXXXAppService \n" +
"    { \n" +
"        private readonly IRepository<Models.XXXEntityPluralXXX, int> _XXXEntityLowerSingularXXXRepository; \n" +
"        private readonly IRepository<Models.Levels, int> _levelRepository; \n" +

"        public XXXEntitySingularXXXAppService( \n" +
"            IRepository<Models.XXXEntityPluralXXX, int> repository, \n" +
"            IRepository<Models.XXXEntityPluralXXX, int> XXXEntityLowerSingularXXXRepository, \n" +
"             IRepository<Models.Levels, int> levelRepository \n" +
"            ) \n" +
"            : base(repository) \n" +
"        { \n" +
"            _XXXEntityLowerSingularXXXRepository = XXXEntityLowerSingularXXXRepository; \n" +
"            _levelRepository = levelRepository; \n" +
"        } \n" +
"        public override async Task<XXXEntitySingularXXXDto> Get(EntityDto<int> input) \n" +
"        { \n" +
"            var user = await base.Get(input); \n" +
"            return user; \n" +
"        } \n" +
"        public override async Task<XXXEntitySingularXXXDto> Create(CreateXXXEntitySingularXXXDto input) \n" +
"        { \n" +
"            CheckCreatePermission(); \n" +
"            var XXXEntityLowerSingularXXX = ObjectMapper.Map<Models.XXXEntityPluralXXX>(input); \n" +
"            await _XXXEntityLowerSingularXXXRepository.InsertAsync(XXXEntityLowerSingularXXX); \n" +
"            return MapToEntityDto(XXXEntityLowerSingularXXX); \n" +
"        } \n" +
"        public override async Task<XXXEntitySingularXXXDto> Update(UpdateXXXEntitySingularXXXDto input) \n" +
"        { \n" +
"            CheckUpdatePermission(); \n" +
"           var XXXEntityLowerSingularXXX = await _XXXEntityLowerSingularXXXRepository.GetAsync(input.Id); \n" +
"           MapToEntity(input, XXXEntityLowerSingularXXX); \n" +
"            await _XXXEntityLowerSingularXXXRepository.UpdateAsync(XXXEntityLowerSingularXXX); \n" +
"            return await Get(input); \n" +
"        } \n" +
"        public override async Task Delete(EntityDto<int> input) \n" +
"        { \n "+
"            var XXXEntityLowerSingularXXX = await _XXXEntityLowerSingularXXXRepository.GetAsync(input.Id); \n"+
"            await _XXXEntityLowerSingularXXXRepository.DeleteAsync(XXXEntityLowerSingularXXX); \n"+
"        } \n"+
"        protected override Models.XXXEntityPluralXXX MapToEntity(CreateXXXEntitySingularXXXDto createInput) \n"+
"        { \n"+
"            var XXXEntityLowerSingularXXX = ObjectMapper.Map<Models.XXXEntityPluralXXX>(createInput); \n"+
"            return XXXEntityLowerSingularXXX; \n"+
"        } \n"+
"        protected override void MapToEntity(UpdateXXXEntitySingularXXXDto input, Models.XXXEntityPluralXXX XXXEntityLowerSingularXXX) \n"+
"        { \n"+
"            ObjectMapper.Map(input, XXXEntityLowerSingularXXX); \n"+
"        } \n"+
"        protected override IQueryable<Models.XXXEntityPluralXXX> CreateFilteredQuery(PagedResultRequestDto input) \n"+
"        { \n"+
"            return Repository.GetAll(); \n"+
"        } \n"+
"        protected  IQueryable<Models.XXXEntityPluralXXX> CreateFilteredByTextQuery(GD.GdPagedResultRequestDto input) \n"+
"        { \n"+
"            var resultado =  Repository.GetAll(); \n"+
"            if (!string.IsNullOrEmpty(input.TextFilter)) \n"+
"                resultado = resultado.Where(x => x.Name.Contains(input.TextFilter)); \n"+
"            return resultado; \n"+
"        } \n"+
"        protected override async Task<Models.XXXEntityPluralXXX> GetEntityByIdAsync(int id) \n"+
"        { \n"+
"            var XXXEntityLowerSingularXXX = Repository.GetAllList().FirstOrDefault(x => x.Id == id); \n"+
"            return await Task.FromResult(XXXEntityLowerSingularXXX); \n"+
"        } \n"+
"        protected override IQueryable<Models.XXXEntityPluralXXX> ApplySorting(IQueryable<Models.XXXEntityPluralXXX> query, PagedResultRequestDto input) \n"+
"        { \n"+
"            return query.OrderBy(r => r.Name); \n"+
"        } \n"+
 
"        protected virtual void CheckErrors(IdentityResult identityResult) \n"+
"        { \n"+
"            identityResult.CheckErrors(LocalizationManager); \n"+
"        } \n"+
        
"        public async Task<PagedResultDto<XXXEntitySingularXXXDto>> GetAllXXXEntityPluralXXX(GdPagedResultRequestDto input) \n"+
"        { \n"+
"            PagedResultDto<XXXEntitySingularXXXDto> ouput = new PagedResultDto<XXXEntitySingularXXXDto>(); \n"+
"            IQueryable<Models.XXXEntityPluralXXX> query = query = from x in _XXXEntityLowerSingularXXXRepository.GetAll() \n"+
"                                                       select x; \n"+
"            if (!string.IsNullOrEmpty(input.TextFilter)) \n"+
"            { \n"+
"                query = from x in _XXXEntityLowerSingularXXXRepository.GetAll() \n"+
"                        where x.Name.Contains(input.TextFilter) \n"+
"                        select x; \n"+
"            } \n"+
"            ouput.TotalCount = await Task.Run(() => { return query.Count(); }); \n"+
"            if (input.SkipCount > 0) \n"+
"            { \n"+
"                query = query.OrderBy(x => x.Id).Skip(input.SkipCount); \n"+
"            } \n"+ 
"            if (input.MaxResultCount > 0) \n"+
"            { \n"+
"                query = query.Take(input.MaxResultCount); \n"+
"            } \n"+
"            ouput.Items = ObjectMapper.Map<List<XXXEntityPluralXXX.Dto.XXXEntitySingularXXXDto>>(query.ToList()); \n"+
"            return ouput; \n"+
"        } \n"+
"    } \n"+
"} ";
    }
}
