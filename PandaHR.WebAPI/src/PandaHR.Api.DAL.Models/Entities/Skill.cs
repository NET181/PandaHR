using System;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Skill : BaseEntity, ISoftDeletable
    {
        public Skill()
        {
            SubSkills = new HashSet<Skill>();
            SkillKnowledges = new HashSet<SkillKnowledge>();
            SkillRequirements = new HashSet<SkillRequirement>();
            TechnologySkills = new HashSet<TechnologySkill>();
        }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public Guid? RootSkillId { get; set; }
        public Skill RootSkill { get; set; }
        public Guid SkillTypeId { get; set; }
        public SkillType SkillType { get; set; } 

        public ICollection<TechnologySkill> TechnologySkills { get; set; }
        public ICollection<Skill> SubSkills { get; set; }
        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
        public ICollection<SkillRequirement> SkillRequirements { get; set; }
    }
}
