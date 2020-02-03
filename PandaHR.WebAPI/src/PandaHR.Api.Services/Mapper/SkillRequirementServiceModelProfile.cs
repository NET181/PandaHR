using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.SkillRequirement;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillRequirementServiceModelProfile : AutoMapperProfile
    {
        public SkillRequirementServiceModelProfile()
        {
            CreateMap<SkillRequirement, SkillRequirementServiceModel>();
        }
    }
}
