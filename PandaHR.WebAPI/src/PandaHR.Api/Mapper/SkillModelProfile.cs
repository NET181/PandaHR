using PandaHR.Api.Common;
using PandaHR.Api.Models.Skill;
using PandaHR.Api.Services.Models.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
