using PandaHR.Api.Services.Models.Experience;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Models.SkillRequirement
{
    public class SkillRequirementRequestModel
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
        public KnowledgeLevelServiceModel KnowledgeLevel { get; set; }
        public SkillServiceModel Skill { get; set; }
        public ExperienceServiceModel Experience { get; set; }
        public int Weight { get; set; }
    }
}
