using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity, ISoftDeletable
    {
        public User()
        {
            Educations = new HashSet<Education>();
            CVs = new HashSet<CV>();
            Vacancies = new HashSet<Vacancy>();
            UserCompanies = new HashSet<UserCompany>();
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Education> Educations;
        public ICollection<CV> CVs;
        public ICollection<Vacancy> Vacancies;
        public ICollection<UserCompany> UserCompanies;
    }
}
