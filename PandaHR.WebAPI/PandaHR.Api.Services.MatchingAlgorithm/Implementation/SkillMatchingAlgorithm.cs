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
        //todo add xml response that ArgumentNullException is possible
        public IEnumerable<ISkillSetWithRatingModel<T>> GetMatchingModels(
                ISkillSetModel<T> pattern,
                IEnumerable<ISkillSetModel<T>> matchingItems,
                double threshold, int take)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            IMatchingGetter<T> matchingGetter = new MatchingGetter<T> { Pattern = pattern };

            return matchingItems
                .AsParallel()
                .Select(s => new SkillSetWithRatingModel<T>()
                {
                    Id = s.Id,
                    Skills = s.Skills,
                    Rating = matchingGetter.GetMatching(s)
                })
                .Take(take)
                .OrderByDescending(m => m.Rating);
            // to do pagination
        }
    }
}
