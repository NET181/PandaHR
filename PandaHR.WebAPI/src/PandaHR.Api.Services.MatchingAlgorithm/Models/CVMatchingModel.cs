using System;
using System.Collections.Generic;
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class CVMatchingModel : ISkillSetModel<Guid>
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> Skills { get; set; }
    }
}
