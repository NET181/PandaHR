using AutoMapper;
using PandaHR.Api.Models.SkillKnowledge;
using PandaHR.Api.Models.SkillRequirement;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.SkillRequirement;

namespace PandaHR.Api.Mapper
{
    public class SkillKnowledgeServiceModelProfile: Profile
    {
        public SkillKnowledgeServiceModelProfile()
        {
            CreateMap<SkillKnowledgeRequestModel, SkillKnowledgeServiceModel>();
            CreateMap<SkillRequirementRequestModel, SkillRequirementServiceModel>();
        }
    }
}
