using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.SkillRequirement;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class SkillRequirementDTOProfile : AutoMapperProfile
    {
        public SkillRequirementDTOProfile()
        {
            CreateMap<SkillRequirement, SkillRequirementDTO>();

            CreateMap<SkillRequirementDTO, SkillRequirement>();
        }
    }
}
