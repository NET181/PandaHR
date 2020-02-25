using PandaHR.Api.DAL.DTOs.Qualification;
using PandaHR.Api.DAL.DTOs.SkillRequirement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.Vacancy
{
    public class VacancyGetDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CityId { get; set; }
        public ICollection<SkillRequirementDTO> SkillRequirements { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
        public QualificationDTO Qualification { get; set; }
        public bool IsActive { get; set; } = false;
        public string Summary { get; set; }
    }
}
