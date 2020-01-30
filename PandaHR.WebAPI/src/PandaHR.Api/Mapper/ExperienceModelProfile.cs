using PandaHR.Api.Common;
using PandaHR.Api.Models.Experience;
using PandaHR.Api.Services.Models.Experience;

namespace PandaHR.Api.Mapper
{
    public class ExperienceModelProfile : AutoMapperProfile
    {
        public ExperienceModelProfile()
        {
            CreateMap<ExperienceServiceModel, ExperienceResponseModel>();
        }
    }
}
