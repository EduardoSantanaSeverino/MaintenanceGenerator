using Abp.Application.Services.Dto;

namespace XXXProjectNameXXX.XXXEntityPluralXXX.Dto
{
    public class PagedXXXEntitySingularXXXResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
