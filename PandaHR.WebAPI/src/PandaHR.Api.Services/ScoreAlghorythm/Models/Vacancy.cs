using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    public class Vacancy
    {
        public List<SkillRequest> SkillRequests { get; set; }
        public Guid Id { get; set; }
        public int Qualification { get; set; }

    }
}
