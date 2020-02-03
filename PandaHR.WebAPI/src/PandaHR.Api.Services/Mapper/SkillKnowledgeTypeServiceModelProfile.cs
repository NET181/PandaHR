using PandaHR.Api.Common;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.SkillKnowledgeType;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Mapper
{
    public class SkillKnowledgeTypeServiceModelProfile : AutoMapperProfile
    {
        public SkillKnowledgeTypeServiceModelProfile()
        {
            CreateMap<SkillKnowledgeType, SkillKnowledgeTypeServiceModel>();
        }
    }
}
