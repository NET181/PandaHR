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

            CreateMap<Education, EducationWithDetailsDTO>();
            CreateMap<Education, EducationBasicInfoDTO>();
            CreateMap<Education, EducationDTO>();
        }
    }
}
