using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.ScoreAlghorythm.Models
{
    class Vacancy
    {
        public List<SkillRequest> SkillRequests { get; set; }
        public int Id { get; set; }
        public int Technology { get; set; }
        public int Qualification { get; set; }

    }
}
