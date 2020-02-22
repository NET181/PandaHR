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

        public string Name { get; set; }
        public Guid SkillTypeId { get; set; }
        public SkillTypeServiceModel SkillType { get; set; }
        public Guid Id { get; set; }
        public Guid? RootSkillId { get; set; }
        public List<SkillServiceModel> SubSkills { get; set; }
    }
}
