using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Mapper
{
    public class SkillDTOProfile : AutoMapperProfile
    {
        public SkillDTOProfile()
        {
            CreateMap<SkillDTO, Skill>();
        }
    }
}
