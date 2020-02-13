using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class VacancyMatchingModel : ISkillContainer
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> SkillIds { get; set; }
    }
}
