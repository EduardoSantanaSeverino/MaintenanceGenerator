using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using SocialUplift.CampaignStates.Dto;
using SocialUplift.Models;

namespace SocialUplift.CampaignStates
{

    [AbpAuthorize]
    public class CampaignStateAppService : SocialUpliftCrudAppServiceBase<CampaignState, CampaignStateDto, int, PagedModelsResultRequestDto, CampaignStateCreateDto, CampaignStateUpdateDto>, ICampaignStateAppService
    {
        public CampaignStateAppService
        (
            IRepository<CampaignState> repository
        )
        : base(repository)
        {
           
        }

    }
}

