using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class Company: BaseEntity
    {
        public Company()
        {
            CompanyCities = new HashSet<CompanyCity>();
            UserCompanies = new HashSet<UserCompany>();
            Vacancies = new HashSet<Vacancy>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CompanyCity> CompanyCities { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
