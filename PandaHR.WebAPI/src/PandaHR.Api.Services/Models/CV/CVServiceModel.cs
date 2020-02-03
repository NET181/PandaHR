using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.SkillKnowledge;

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
        public Qualification Qualification { get; set; }
        public Technology Technology { get; set; }

        public ICollection<SkillForSearchDTO> Skills { get; set; }
    }
}
