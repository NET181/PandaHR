using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Implementation
{
    public class SkillMatchingAlgorithm : ISkillMatchingAlgorithm
    {
        public IEnumerable<MatchingAlgorithmResponceModel> GetMatchingModels(
            ISkillContainer pattern,
            IEnumerable<ISkillContainer> matchingItems,
            double threshold)
        {
            return matchingItems
                .AsParallel()
                .Select(
                m => new MatchingAlgorithmResponceModel
                {
                    Id = m.Id,
                    Matching = pattern.SkillIds.GetMatching(m.SkillIds)
                })
                .Where(m => m.Matching >= threshold)
                .OrderByDescending(m => m.Matching);
        }
    }
}
