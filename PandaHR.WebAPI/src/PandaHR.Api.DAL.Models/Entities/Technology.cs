using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Technology : BaseEntity, ISoftDeletable
    {
        public Technology()
        {
            TechnologySkills = new HashSet<TechnologySkill>();
            CVs = new HashSet<CV>();
            Vacancies = new HashSet<Vacancy>();
        }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? ParentId { get; set; }
        public Technology Parent { get; set; }

        public ICollection<Technology> SubTechnologies { get; set; }
        public ICollection<TechnologySkill> TechnologySkills { get; set; }
        public ICollection<CV> CVs { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
