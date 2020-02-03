using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.Services.Models.SkillKnowledge;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillKnowledgeServiceModelProfile : AutoMapperProfile
    {
        public SkillKnowledgeServiceModelProfile()
        {
            CreateMap<SkillKnowledgeServiceModel, SkillKnowledgeDTO>();
        }
    }
}
