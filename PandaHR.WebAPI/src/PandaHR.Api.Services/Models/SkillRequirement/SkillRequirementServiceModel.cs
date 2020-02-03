using System;

namespace PandaHR.Api.Services.Models.SkillRequirement
{
    public class SkillRequirementServiceModel
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
        public float Weight { get; set; }
    }
}
