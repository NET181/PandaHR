using System;
using System.Collections.Generic;

namespace PandaHR.Api.Models.Skill
{
    public class SkillResponseModel
    {
        public SkillResponseModel()
        {
            SubSkills = new List<SkillResponseModel>();
        }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<SkillResponseModel> SubSkills { get; set; }
    }
}
