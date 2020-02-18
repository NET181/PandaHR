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

            return matchingItems
                .AsParallel()
                .Select(s => new SkillSetWithRating<T>()
                {
                    Id = s.Id,
                    Skills = s.Skills,
                    Rating = s.Skills.Intersect(pattern.Skills).Count() //todo add method or class
                })
                .Take(take)
                .OrderByDescending(m => m.Rating);
        }
    }
}
