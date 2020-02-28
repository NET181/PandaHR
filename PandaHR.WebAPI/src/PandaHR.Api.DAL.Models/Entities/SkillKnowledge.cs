using System;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillKnowledge : ISoftDeletable
    {
        public bool IsDeleted { get; set; }

        public Skill Skill { get; set; }
        public Guid SkillId { get; set; }

        public KnowledgeLevel KnowledgeLevel { get; set; }
        public Guid KnowledgeLevelId { get; set; }

        public Experience Experience { get; set; }
        public Guid ExperienceId { get; set; }
        
        public CV CV { get; set; }
        public Guid CVId { get; set; }
    }
}
