using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG
{
    public class IAppServiceCreator
    {

        public static string TemplateIAppService = "using System.Threading.Tasks; \n" +
             "using Abp.Application.Services;\n" +
             "using Abp.Application.Services.Dto;\n" +
             "using GEDUCON.Courses.Dto;\n" +
             "using GEDUCON.GD;\n\n" +
             "namespace GEDUCON.XXXEntityPluralXXX\n" +
             "{\n" +
             "      public interface IXXXEntitySingularXXXAppService : IAsyncCrudAppService<XXXEntitySingularXXXDto, int, PagedResultRequestDto, CreateXXXEntitySingularXXXDto, UpdateXXXEntitySingularXXXDto>\n" +
             "      {\n" +
             "             Task<PagedResultDto<XXXEntitySingularXXXDto>> GetAllXXXEntityPluralXXX(GdPagedResultRequestDto input);\n" +
             "      }\n" +
             "}";
    }
}
