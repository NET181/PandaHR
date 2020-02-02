using PandaHR.Api.Services.Mapper;
using PandaHR.Api.Services.Models.Experience;
using PandaHR.Api.Services.Models.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Models.SkillKnowledge
{
    public class SkillKnowledgeServiceModel
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }

    }
}
