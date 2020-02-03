using System;

namespace PandaHR.Api.Services.Models.Skill
{
    public class SkillServiceModel
    {
        public Guid SkillId { get; set; }
        public Guid SkillKnowledgeId { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
