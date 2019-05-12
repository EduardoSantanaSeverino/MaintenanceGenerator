using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using SocialUplift.Authorization.Users;
using SocialUplift.Models;

namespace SocialUplift.CampaignStates.Dto
{
    [AutoMapFrom(typeof(CampaignState))]
    public class CampaignStateDto : EntityDto<int>
    {

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
