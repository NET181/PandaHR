using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Services.Mapper
{
    public class EducationServiceModelProfile : AutoMapperProfile
    {
        public EducationServiceModelProfile()
        {
            CreateMap<EducationWithDetailsServiceModel, EducationWithDetailsDTO>();

            CreateMap<EducationDTO, EducationWithDetailsServiceModel>();

            CreateMap<EducationBasicInfoDTO, EducationBasicInfoServiceModel>();
        }
    }
}
