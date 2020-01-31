﻿using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Models.Skill;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Models.CV
{
    public class CVCreationRequestModel
    {
        public string Summary { get; set; }
        public ICollection<SkillKnowledgeServiceModel> SkillKnowledges { get; set; }
        public ICollection<JobExperienceServiceModel> JobExperiences { get; set; }
        public UserCreationServiceModel User { get; set; }
        public ICollection<EducationWithDetailsServiceModel> Educations { get; set; }
        public bool IsActive { get; set; } = false;
    }
}