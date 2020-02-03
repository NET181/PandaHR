using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.DTOs.SkillRequirement;
using PandaHR.Api.DAL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.Vacancy
{
    public class VacancyDTO
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CityId { get; set; }
        public ICollection<SkillRequirementDTO> SkillRequirements { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
