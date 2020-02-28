using System.Collections.Generic;

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

