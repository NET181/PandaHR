using System;

namespace PandaHR.Api.Models.SkillKnowledge
{
    public class SkillKnowledgeRequestModel
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
