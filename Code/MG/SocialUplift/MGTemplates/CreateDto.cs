using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using SocialUplift.Models;

namespace SocialUplift.CampaignStates.Dto
{
    [AutoMapTo(typeof(CampaignState))]
    public class CampaignStateCreateDto : EntityDto<int>
    {

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
