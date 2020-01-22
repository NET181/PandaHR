using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class KnowledgeLevel : BaseEntity , ISoftDeletable
    {
        public KnowledgeLevel()
        {
            SkillRequirements = new HashSet<SkillRequirement>();
            SkillKnowledges = new HashSet<SkillKnowledge>();
        }

        public bool IsDeleted { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        public SkillType SkillType { get; set; }
        public Guid SkillTypeId { get; set; }

        public ICollection<SkillRequirement> SkillRequirements { get; set; }
        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
       
    }
}