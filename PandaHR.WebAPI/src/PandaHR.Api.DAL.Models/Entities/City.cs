using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class City : BaseEntity, ISoftDeletable
    {
        public City()
        {
            CompanyCities = new HashSet<CompanyCity>();
            Vacancies = new HashSet<Vacancy>();
        }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<CompanyCity> CompanyCities { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

    }
}
