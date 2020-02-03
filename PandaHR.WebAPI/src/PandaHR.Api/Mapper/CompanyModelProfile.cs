using PandaHR.Api.Common;
using PandaHR.Api.Models.Company;
using PandaHR.Api.Services.Models.Company;

namespace PandaHR.Api.Mapper
{
    public class CompanyModelProfile : AutoMapperProfile
    {
        public CompanyModelProfile()
        {
            CreateMap<CompanyNameServiceModel, CompanyNameResponseModel>();
        }
    }
}
