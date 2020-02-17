using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillMatchingAlgorithm<T>
    {
        public IEnumerable<MatchingAlgorithmResponceModel>
            GetMatchingModels(
            IMatchingModel<T> pattern,
            IEnumerable<IMatchingModel<T>> matchingItems, 
            double threshold);
    }
}

