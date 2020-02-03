using System;

namespace PandaHR.Api.Services.Models.SkillKnowledge
{
    public class SkillKnowledgeServiceModel
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
