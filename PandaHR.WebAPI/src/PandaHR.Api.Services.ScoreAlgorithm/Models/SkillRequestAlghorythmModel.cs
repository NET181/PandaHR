﻿namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{
    public class SkillRequestAlghorythmModel
    {
        public SkillAlghorythmModel Skill { get; set; }
        public int Weight { get; set; }
        public int Expirience { get; set; }
        public int KnowledgeLevel { get; set; }
    }
}