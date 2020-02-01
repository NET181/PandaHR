using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class Skill
    {
        public string Name { get; set; }
        public int SkillType { get; set; }
        public List<Skill> SupSkills { get; set; }
    }
}
