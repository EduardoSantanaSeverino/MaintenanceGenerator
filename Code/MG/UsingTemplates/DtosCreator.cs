using System;

namespace MG
{
    class DtosCreator
    {
        public static String EntityDto_JustStartLines =
            "using System; \n" +
            "using System.ComponentModel.DataAnnotations; \n" +
            "using Abp.Application.Services.Dto; \n" +
            "using Abp.Authorization.Users; \n" +
            "using Abp.AutoMapper; \n" +

            "namespace GEDUCON.XXXEntityPluralXXX.Dto \n" +
            "{\n " +
            "        [AutoMap(typeof(Models.XXXEntityPluralXXX))] \n" +
            "        public class XXXEntitySingularXXXDto : EntityDto<int> \n" +
            "        {";


        public static String UpdateDto_JustStartLines =
            "using System; \n" +
            "using System.ComponentModel.DataAnnotations; \n" +
            "using Abp.Application.Services.Dto; \n" +
            "using Abp.Authorization.Users; \n" +
            "using Abp.AutoMapper; \n" +

            "namespace GEDUCON.XXXEntityPluralXXX.Dto \n" +
            "{\n " +
            "        [AutoMap(typeof(Models.XXXEntityPluralXXX))] \n" +
            "        public class UpdateXXXEntitySingularXXXDto : EntityDto<int> \n" +
            "        {";

        public static String CreateDto_JustStartLines =
            "using System; \n" +
            "using System.ComponentModel.DataAnnotations; \n" +
            "using Abp.Application.Services.Dto; \n" +
            "using Abp.Authorization.Users; \n" +
            "using Abp.AutoMapper; \n" +

            "namespace GEDUCON.XXXEntityPluralXXX.Dto \n" +
            "{\n " +
            "        [AutoMap(typeof(Models.XXXEntityPluralXXX))] \n" +
            "        public class CreateXXXEntitySingularXXXDto : EntityDto<int> \n" +
            "        {";
    }
}
