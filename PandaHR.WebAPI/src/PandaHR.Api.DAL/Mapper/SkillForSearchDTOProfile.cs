using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;

namespace PandaHR.Api.DAL.Mapper
{
    public class SkillForSearchDTOProfile : AutoMapperProfile
    {
        public SkillForSearchDTOProfile()
        {
            CreateMap<SkillKnowledge, SkillForSearchDTO>()
                .ForMember(d => d.SkillName, opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(d => d.KnowledgeLevelName, opt => opt.MapFrom(src => src.KnowledgeLevel.Name));
        }
    }
}
