using System;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class CV : BaseEntity, ISoftDeletable
    {
        public CV()
        {
            JobExperiences = new HashSet<JobExperience>();
            SkillKnowledges = new HashSet<SkillKnowledge>();
        }

        public bool IsDeleted { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public Guid QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public Guid TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public ICollection<JobExperience> JobExperiences { get; set; }
        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
    }
}
