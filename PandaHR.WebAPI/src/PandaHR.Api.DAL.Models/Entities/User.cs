using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PandaHR.Api.DAL.Models.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity, ISoftDeletable
    {
        public User()
        {
            Educations = new HashSet<Education>();
            Vacancies = new HashSet<Vacancy>();
            UserCompanies = new HashSet<UserCompany>();
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Guid? CityId { get; set; }
        public City City { get; set; }
        public Guid? CVId { get; set; }
        public CV CV { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Education> Educations { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
