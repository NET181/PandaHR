using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class TechnologySkill : ISoftDeletable
    {
        public bool IsDeleted { get; set; }

        public Guid TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
