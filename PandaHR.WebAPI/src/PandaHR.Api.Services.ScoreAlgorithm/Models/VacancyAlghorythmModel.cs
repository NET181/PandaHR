using System;
using System.Collections.Generic;

namespace PandaHR.Api.Services.ScoreAlgorithm.Models
{ 
    public class VacancyAlghorythmModel
    {
        public VacancyAlghorythmModel()
        {
            SkillRequests = new List<SkillRequestAlghorythmModel>();
        }

        public List<SkillRequestAlghorythmModel> SkillRequests { get; set; }
        public Guid Id { get; set; }
        public int Qualification { get; set; }

    }
}
