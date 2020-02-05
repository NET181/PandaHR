using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Skill;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Mapper
{
    public class SkillModelProfile : AutoMapperProfile
    {
        public SkillModelProfile()
        {
            CreateMap<SkillNameServiceModel, SkillNameResponseModel>();
        }
    }
}
