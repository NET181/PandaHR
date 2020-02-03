using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.SkillRequirement;
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
            CreateMap<SkillRequirementServiceModel, SkillRequirementDTO>();

            CreateMap<SkillRequirementDTO, SkillRequirementServiceModel>();
        }
    }
}
