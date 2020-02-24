using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaHR.Api.Services.MatchingAlgorithm.Implementation
{
    public class SkillMatchingAlgorithm<T> : ISkillMatchingAlgorithm<T>
    {
        public IEnumerable<ISkillSetWithRatingModel<T>> GetMatchingModels(
                ISkillSetModel<T> pattern,
                IEnumerable<ISkillSetModel<T>> matchingItems,
                int threshold, int take)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            IMatchingGetter<T> matchingGetter = new MatchingGetter<T>(pattern);

            return matchingItems
                .AsParallel()
                .Select(s => new SkillSetWithRatingModel<T>()
                {
                    Id = s.Id,
                    Skills = s.Skills,
                    Rating = matchingGetter.GetMatching(s)
                })
                .Where(s => s.Rating >= threshold)
                .Take(take)
                .OrderByDescending(m => m.Rating);
        }
    }
}
