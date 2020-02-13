using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.SkillRequirement;
using PandaHR.Api.Services.Models.SkillRequirement;
using PandaHR.Api.Services.MatchingAlgorithm.Models;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillRequirementServiceModelProfile : AutoMapperProfile
    {
        public SkillRequirementServiceModelProfile()
        {
            CreateMap<SkillRequirement, SkillRequirementServiceModel>();

            CreateMap<SkillRequirementServiceModel, SkillRequirementDTO>();

            CreateMap<SkillRequirementDTO, SkillRequirementServiceModel>();
        }
    }
}
