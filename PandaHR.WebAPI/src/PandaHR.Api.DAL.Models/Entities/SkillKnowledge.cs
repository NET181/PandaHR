using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillKnowledge : BaseEntity
    {
        public int Experience { get; set; }

        public Skill Skill { get; set; }
        public Guid SkillId { get; set; }

        public KnowledgeLevel KnowledgeLevel{ get; set; }
        public Guid KnowledgeLevelId { get; set; }
        
        public CV CV { get; set; }
        public Guid CVId { get; set; }
    }
}
