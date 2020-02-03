using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Vacancy;

namespace PandaHR.Api.Services.Mapper
{
    public class VacancyServiceModelProfile : AutoMapperProfile
    {
        public VacancyServiceModelProfile()
        {
            CreateMap<Vacancy, VacancyServiceModel>();
        }
    }
}
