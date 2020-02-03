using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillServiceModelProfile : AutoMapperProfile
    {
        public SkillServiceModelProfile()
        {
            CreateMap<SkillNameDTO, SkillNameServiceModel>();

            CreateMap<SkillServiceModel, SkillDTO>();
        }
    }
}
