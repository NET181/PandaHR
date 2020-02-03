using PandaHR.Api.Common;
using PandaHR.Api.Models.Education;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Mapper
{
    public class EducationServiceModelProfile : AutoMapperProfile
    {
        public EducationServiceModelProfile()
        {
            CreateMap<EducationBasicInfoServiceModel, EducationBasicInfoResponse>();
        }
    }
}
