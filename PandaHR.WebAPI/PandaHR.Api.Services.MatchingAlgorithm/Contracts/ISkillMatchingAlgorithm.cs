using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillMatchingAlgorithm<T>
    {
        public IEnumerable<ISkillSetWithRatingModel<T>> GetMatchingModels(
            ISkillSetModel<T> pattern,
            IEnumerable<ISkillSetModel<T>> matchingItems, 
            int threshold,
            int take);
    }
}

