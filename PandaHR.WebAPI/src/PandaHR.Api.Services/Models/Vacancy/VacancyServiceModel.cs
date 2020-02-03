
using PandaHR.Api.Services.Models.Experience;
using PandaHR.Api.Services.Models.Qualification;
using PandaHR.Api.Services.Models.SkillRequirement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Models.Vacancy
{
    public class VacancyServiceModel
    {
        public Guid Id { get; set; }
        
        public string Summary { get; set; }
        public ICollection<SkillRequirementServiceModel> SkillRequirements { get; set; }
        public bool IsActive { get; set; } = false;
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
        public QualificationServiceModel Qualification { get; set; }

    }
}
