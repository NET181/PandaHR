using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models;
using PandaHR.Api.Services.Models.SkillRequirement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillRequirementServiceModelProfile : AutoMapperProfile
    {
        public SkillRequirementServiceModelProfile()
        {
            CreateMap<SkillRequirement, SkillRequirementServiceModel>();
        }
    }
}
