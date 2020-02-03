using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class SkillAlghorythmModel
    {
        public SkillAlghorythmModel()
        {
            SupSkills = new List<SkillAlghorythmModel>();
        }
        public Guid Id { get; set; }
        public int SkillType { get; set; }
        public List<SkillAlghorythmModel> SupSkills { get; set; }
    }
}
