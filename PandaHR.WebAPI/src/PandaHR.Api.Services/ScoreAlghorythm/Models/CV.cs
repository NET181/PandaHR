using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
   public class CV
    {
        public Guid Id { get; set; }
        public List<SkillKnowledge> SkillKnowledges { get; set; }
        public int Qualification { get; set; }
    }
}

