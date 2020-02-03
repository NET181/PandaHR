using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.SkillRequirement
{
    public class SkillRequirementDTO
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
        public float Weight { get; set; }
    }
}
