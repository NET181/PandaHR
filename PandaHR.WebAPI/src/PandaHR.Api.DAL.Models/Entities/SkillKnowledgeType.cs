using System;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillKnowledgeType : ISoftDeletable
    {
        public int Value { get; set; }
        public bool IsDeleted { get; set; }

        public Guid SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }
        public Guid KnowledgeLevelId { get; set; }
        public KnowledgeLevel KnowledgeLevel { get; set; }
    }
}
