using System;
using System.Collections.Generic;

namespace PandaHR.Api.Services.Models.Skill
{
    public class SkillServiceModel
    {
        public SkillServiceModel()
        {
            SubSkills = new List<SkillServiceModel>();
        }
        public SkillTypeServiceModel SkillType { get; set; }
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Guid SkillKnowledgeId { get; set; }
        public Guid ExperienceId { get; set; }
        public List<SkillServiceModel> SubSkills { get; set; }
    }
}
