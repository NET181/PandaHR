using System;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class City : BaseEntity, ISoftDeletable
    {
        public City()
        {
            CompanyCities = new HashSet<CompanyCity>();
            VacancyCities = new HashSet<VacancyCity>();
        }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<CompanyCity> CompanyCities { get; set; }
        public ICollection<VacancyCity> VacancyCities { get; set; }
    }
}
