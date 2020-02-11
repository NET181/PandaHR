using AutoMapper;
using PandaHR.Api.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.SkillKnowledge;

namespace PandaHR.Api.Mapper
{
    public class SkillKnowledgeServiceModelProfile: Profile
    {
        public SkillKnowledgeServiceModelProfile()
        {
            CreateMap<SkillKnowledgeRequestModel, SkillKnowledgeServiceModel>();
        }
    }
}
