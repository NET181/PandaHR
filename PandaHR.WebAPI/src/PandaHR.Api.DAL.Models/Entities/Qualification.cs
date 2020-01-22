using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Qualification : BaseEntity, ISoftDeletable
    {
        public Qualification()
        {
            CVs = new HashSet<CV>();
            Vacancies = new HashSet<Vacancy>();
        }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public ICollection<CV> CVs { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
