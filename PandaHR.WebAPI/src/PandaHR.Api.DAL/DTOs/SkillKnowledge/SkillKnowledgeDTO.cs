using System;

namespace PandaHR.Api.DAL.DTOs.SkillKnowledge
{
    public class SkillKnowledgeDTO
    {
        public Guid SkillId { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public Guid ExperienceId { get; set; }
    }
}
