using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    class CV
    {
        public int Id { get; set; }
        public List<SkillKnowledge> SkillKnowledges { get; set; }
        public int Tech { get; set; }
        public int Qualification { get; set; }
    }
}

