using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using XXXProjectNameXXX.Models;

namespace XXXProjectNameXXX.XXXEntityPluralXXX.Dto
{
    [AutoMapFrom(typeof(XXXEntitySingularXXX))]
    public class XXXEntitySingularXXXDto : EntityDto<XXXSpecificTypeXXX>
    {

///Dto.cs.fields1///

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

    }
}
