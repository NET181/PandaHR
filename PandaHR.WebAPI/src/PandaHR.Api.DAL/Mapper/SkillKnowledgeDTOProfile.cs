using PandaHR.Api.Common;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Mapper
{
    public class SkillKnowledgeDTOProfile : AutoMapperProfile
    {
        public SkillKnowledgeDTOProfile()
        {
            CreateMap<SkillKnowledgeDTO, SkillKnowledge>();
        }
    }
}
