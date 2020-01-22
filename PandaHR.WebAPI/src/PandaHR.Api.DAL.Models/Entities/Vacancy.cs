using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Vacancy : BaseEntity, ISoftDeletable
    {
        public Vacancy()
        {
            SkillRequirements = new HashSet<SkillRequirement>();
        }

        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid? CityId { get; set; }
        public City City { get; set; }

        public ICollection<SkillRequirement> SkillRequirements { get; set; }
    }
}
