using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    class Skill
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int? Technology { get; set; }
        public int SkillType { get; set; }
        public List<Skill> SupSkills { get; set; }
        public Skill RootSkill { get; set; }
    }
}
