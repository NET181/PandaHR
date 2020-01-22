using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class SkillKnowledge
    {
        public Guid CVId { get; set; }
        public CV CV { get; set; }
    }
}
