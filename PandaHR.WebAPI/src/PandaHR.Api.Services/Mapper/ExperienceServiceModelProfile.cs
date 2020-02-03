using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Experience;
using PandaHR.Api.Services.Models.Experience;

namespace PandaHR.Api.Services.Mapper
{
    public class ExperienceServiceModelProfile : AutoMapperProfile
    {
        public ExperienceServiceModelProfile()
        {
            CreateMap<ExperienceDTO, ExperienceServiceModel>();
        }
    }
}
