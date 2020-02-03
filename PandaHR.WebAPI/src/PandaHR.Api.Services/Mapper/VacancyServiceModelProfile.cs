using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;

namespace PandaHR.Api.Services.Mapper
{
    public class VacancyServiceModelProfile : AutoMapperProfile
    {
        public VacancyServiceModelProfile()
        {
            CreateMap<VacancyServiceModel, VacancyDTO>();

            CreateMap<VacancyDTO, VacancyServiceModel>();
        }
    }
}
