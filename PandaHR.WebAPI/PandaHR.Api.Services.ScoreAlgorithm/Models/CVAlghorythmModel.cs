using System;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{
    public class CVAlghorythmModel
    {
        public CVAlghorythmModel()
        {
            SkillKnowledges = new List<SkillKnowledgeAlghorythmModel>();
        }
        public Guid Id { get; set; }
        public List<SkillKnowledgeAlghorythmModel> SkillKnowledges { get; set; }
        public int Qualification { get; set; }
    }
}

