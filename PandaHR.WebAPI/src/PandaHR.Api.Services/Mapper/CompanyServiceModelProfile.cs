using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.Services.Models.Company;

namespace PandaHR.Api.Services.Mapper
{
    public class CompanyServiceModelProfile : AutoMapperProfile 
    {
        public CompanyServiceModelProfile()
        {
            CreateMap<CompanyNameDTO, CompanyNameServiceModel>();
        }
    }
}
