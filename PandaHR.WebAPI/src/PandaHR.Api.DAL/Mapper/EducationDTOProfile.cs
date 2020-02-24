using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class EducationDTOProfile : AutoMapperProfile
    {
        public EducationDTOProfile()
        {
            CreateMap<EducationDTO, Education>();
            CreateMap<EducationWithDetailsDTO, Education>()
                .ForPath(e => e.Speciality.Name, s => s.MapFrom(o => o.Speciality));

            CreateMap<Education, EducationExportDTO>()
                .ForMember(dest => dest.Period, opt =>
                    opt.MapFrom(src => $"{src.DateStart.ToShortDateString()} - {src.DateEnd.ToShortDateString()}"))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree.Name))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.PlaceName))
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.Speciality.Name));    
            CreateMap<Education, EducationWithDetailsDTO>();
            CreateMap<Education, EducationNameDTO>();
            CreateMap<Education, EducationDTO>();
        }
    }
}
