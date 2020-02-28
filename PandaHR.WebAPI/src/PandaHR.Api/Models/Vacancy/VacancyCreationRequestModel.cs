using System;
using System.Collections.Generic;
using PandaHR.Api.Models.Qualification;
using PandaHR.Api.Models.SkillRequirement;
using PandaHR.Api.Services.Models.Qualification;
using PandaHR.Api.Services.Models.SkillRequirement;

namespace PandaHR.Api.Models.Vacancy
{
    public class VacancyCreationRequestModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CityId { get; set; }
        public ICollection<SkillRequirementRequestModel> SkillRequirements { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
        public QualificationResponseModel Qualification { get; set; }
        public bool IsActive { get; set; } = false;
        public string Summary { get; set; }
    }
}
