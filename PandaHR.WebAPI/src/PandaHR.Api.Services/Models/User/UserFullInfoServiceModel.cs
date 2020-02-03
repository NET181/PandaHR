using PandaHR.Api.Services.Models.City;
using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.JobExperience;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Models.User
{
    public class UserFullInfoServiceModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<EducationWithDetailsServiceModel> Educations { get; set; }
        public CityWithNameServiceModel City { get; set; }
    }
}
