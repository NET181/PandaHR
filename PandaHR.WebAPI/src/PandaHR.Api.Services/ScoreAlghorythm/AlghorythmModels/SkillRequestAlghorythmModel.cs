using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class SkillRequestAlghorythmModel
    {
        public SkillAlghorythmModel Skill { get; set; }
        public int Weight { get; set; }
        public int Expiriense { get; set; }
        public int KnowledgeLevel { get; set; }
    }
}