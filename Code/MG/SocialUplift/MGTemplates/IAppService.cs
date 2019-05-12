using Abp.Application.Services.Dto;
using SocialUplift.CampaignStates.Dto;

namespace SocialUplift.CampaignStates
{
    public interface ICampaignStateAppService : ISocialUpliftCrudAppServiceBase<CampaignStateDto, int, PagedModelsResultRequestDto, CampaignStateCreateDto, CampaignStateUpdateDto>
    {
      
    }
}
