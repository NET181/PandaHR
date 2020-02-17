using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Implementation
{
    public class SkillMatchingAlgorithm<T> : ISkillMatchingAlgorithm<T>
    {
        public IEnumerable<MatchingAlgorithmResponceModel> 
            GetMatchingModels(
            IMatchingModel<T> pattern,
            IEnumerable<IMatchingModel<T>> matchingItems,
            double threshold)
        {
            return matchingItems
                .AsParallel()
                .Select(m => new MatchingAlgorithmResponceModel
                {
                    Id = m.Id,
                    Matching = pattern.MatchingSet.GetMatching(m.MatchingSet)
                })
                .Where(m => m.Matching >= threshold)
                .OrderByDescending(m => m.Matching);
        }
    }
}
