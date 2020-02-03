using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.Skill;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillServiceModelProfile : AutoMapperProfile
    {
        public SkillServiceModelProfile()
        {
            CreateMap<SkillServiceModel, SkillDTO>();

            CreateMap<Skill, SkillServiceModel>();
        }
    }
}
