using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class CVMatchingModel : IMatchingModel<Guid>
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> MatchingSet { get; set; }
    }
}
