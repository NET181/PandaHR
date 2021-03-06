﻿using System;
using System.Collections.Generic;
using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;

namespace PandaHR.Api.Models.CV
{
    public class CVCreationRequestModel
    {
        public string Summary { get; set; }
        public ICollection<SkillKnowledgeServiceModel> SkillKnowledges { get; set; }
        public ICollection<JobExperienceServiceModel> JobExperiences { get; set; }
        public Guid? UserId { get; set; }
        public UserCreationServiceModel User { get; set; }
        public ICollection<EducationWithDetailsServiceModel> Educations { get; set; }
        public bool IsActive { get; set; } = false;
        public Guid TechnologyId { get; set; }
        public Guid QualificationId { get; set; }
    }
}