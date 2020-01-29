using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class KnowledgeLevel : BaseEntity , ISoftDeletable
    {
        public KnowledgeLevel()
        {
            SkillRequirements = new HashSet<SkillRequirement>();
            SkillKnowledges = new HashSet<SkillKnowledge>();
            SkillKnowledgeTypes = new HashSet<SkillKnowledgeType>();
        }

        public bool IsDeleted { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        //public SkillType SkillType { get; set; }
        //public Guid SkillTypeId { get; set; }

        public ICollection<SkillKnowledgeType> SkillKnowledgeTypes { get; set; }
        public ICollection<SkillRequirement> SkillRequirements { get; set; }
        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
       
    }
}