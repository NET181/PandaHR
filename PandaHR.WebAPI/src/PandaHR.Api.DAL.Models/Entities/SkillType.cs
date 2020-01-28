using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillType : BaseEntity, ISoftDeletable
    {
        public SkillType()
        {
            Skills = new HashSet<Skill>();
            SkillKnowledgeTypes = new HashSet<SkillKnowledgeType>();
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Skill> Skills { get; set; }
        public ICollection<SkillKnowledgeType> SkillKnowledgeTypes {get;set;}
    }
}
