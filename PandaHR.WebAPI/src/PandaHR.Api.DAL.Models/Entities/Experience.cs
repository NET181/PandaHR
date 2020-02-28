using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Experience : BaseEntity, ISoftDeletable
    {
        public Experience()
        {
            SkillRequirements = new HashSet<SkillRequirement>();
            SkillKnowledges = new HashSet<SkillKnowledge>();
        }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<SkillRequirement> SkillRequirements { get; set; }
        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
    }
}
