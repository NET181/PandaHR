using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.DTOs.Education;
using System;
using System.Collections.Generic;

namespace PandaHR.Api.DAL.DTOs.User
{
    public class UserFullInfoDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<EducationDTO> Educations { get; set; }
        public ICollection<CompanyWithDetailsDTO> Companies { get; set; }
        public CityDTO City { get; set; }
    }
}
