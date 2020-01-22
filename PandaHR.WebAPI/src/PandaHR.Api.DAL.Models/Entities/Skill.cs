using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Skill : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ParentId { get; set; }
        public Skill Parent { get; set; }
        
        public ICollection<Skill> Skills { get; set; }
    }
}
