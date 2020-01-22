using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillType: BaseEntity, ISoftDeletable
    {
        public SkillType()
        {
            Skills = new HashSet<Skill>();
            KnowledgeLevels = new HashSet<KnowledgeLevel>();
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Skill> Skills { get; set; }
        public ICollection<KnowledgeLevel> KnowledgeLevels { get; set; }
    }
}
