using System;
using System.Collections.Generic;
using PandaHR.Api.Services.Models.City;
using PandaHR.Api.Services.Models.Company;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Models.User
{
    public class UserFullInfoResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<EducationWithDetailsServiceModel> Educations { get; set; }
        public ICollection<CompanyNameServiceModel> Companies { get; set; }
        public CityNameServiceModel City { get; set; }
    }
}
