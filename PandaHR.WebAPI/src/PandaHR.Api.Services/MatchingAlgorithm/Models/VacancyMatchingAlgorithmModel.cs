using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class VacancyMatchingAlgorithmModel
    {
        public Guid Id { get; set; }

        public ICollection<SkillRequirementMatchingAlgorithmModel> SkillRequirements;
    }
}
