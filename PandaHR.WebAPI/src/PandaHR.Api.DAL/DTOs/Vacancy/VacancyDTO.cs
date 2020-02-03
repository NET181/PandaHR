using PandaHR.Api.DAL.DTOs.SkillRequirement;
using System;
using System.Collections.Generic;

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
