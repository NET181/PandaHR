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
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
