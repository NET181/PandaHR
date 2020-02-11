using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class CVMatchingAlgorithmModel
    {
        public Guid Id { get; set; }

        public ICollection<SkillKnowledgeMatchingAlgorithmModel> SkillKnowledges { get; set; }
    }
}
