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
            CreateMap<EducationWithDetailsDTO, Education>();

            CreateMap<Education, EducationWithDetailsDTO>();
            CreateMap<Education, EducationBasicInfoDTO>();
            CreateMap<Education, EducationDTO>();
        }
    }
}
