using PandaHR.Api.DAL.DTOs.Experience;
using PandaHR.Api.DAL.DTOs.KnowledgeLevel;
using PandaHR.Api.DAL.DTOs.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.SkillRequirement
{
    public class SkillRequirementGetDTO
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
        public KnowledgeLevelDTO KnowledgeLevel { get; set; }
        public SkillNameDTO Skill { get; set; }
        public ExperienceDTO Experience { get; set; }
        public int Weight { get; set; }
    }
}
