using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;
using PandaHR.Api.Services.Models.Qualification;

namespace PandaHR.Api.Services.Models.CV
{
    public class CVServiceModel
    {
        public Guid Id { get; set; }

        public UserCreationServiceModel User { get; set; }
        public ICollection<EducationWithDetailsServiceModel> Educations { get; set; }
        public string Summary { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public Guid QualificationId { get; set; }
        public QualificationServiceModel Qualification { get; set; }
        public Guid TechnologyId { get; set; }
        public ICollection<SkillKnowledgeServiceModel> SkillKnowledges { get; set; }
        public ICollection<JobExperienceServiceModel> JobExperiences { get; set; }
        public ICollection<SkillForSearchDTO> Skills { get; set; }
    }
}
