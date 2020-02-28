using System;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Vacancy : BaseEntity, ISoftDeletable
    {
        public Vacancy()
        {
            SkillRequirements = new HashSet<SkillRequirement>();
            VacancyCities = new HashSet<VacancyCity>();
            CVs = new HashSet<VacancyCVFlow>();
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

        public Guid TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public ICollection<SkillRequirement> SkillRequirements { get; set; }
        public ICollection<VacancyCity> VacancyCities { get; set; }
        public ICollection<VacancyCVFlow> CVs {get; set;}
    }
}
