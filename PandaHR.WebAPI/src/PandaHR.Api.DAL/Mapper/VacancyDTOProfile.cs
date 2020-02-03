using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class VacancyDTOProfile : AutoMapperProfile
    {
        public VacancyDTOProfile()
        {
            CreateMap<Vacancy, VacancySummaryDTO>()
               .ForMember(dest => dest.QualificationName, opt => opt.MapFrom(src => src.Qualification.Name))
               .ForMember(dest => dest.TechnologyName, opt => opt.MapFrom(src => src.Technology.Name))
               .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<VacancyDTO, Vacancy>();
        }
    }
}
