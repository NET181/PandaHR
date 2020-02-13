using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System.Linq;

namespace PandaHR.Api.Services.Mapper
{
    public class VacancyServiceModelProfile : AutoMapperProfile
    {
        public VacancyServiceModelProfile()
        {
            CreateMap<Vacancy, VacancyServiceModel>();

            CreateMap<VacancyServiceModel, VacancyDTO>();

            CreateMap<VacancyDTO, VacancyServiceModel>();

            CreateMap<Vacancy, VacancyMatchingModel>()
                .ForMember(x => x.SkillIds, o => o.MapFrom(c => c.SkillRequirements.Select(s => s.SkillId)));
        }
    }
}
