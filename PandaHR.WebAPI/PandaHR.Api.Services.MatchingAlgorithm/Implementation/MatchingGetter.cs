using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Implementation
{
    public class MatchingGetter<T> : IMatchingGetter<T>
    {
        private const int PERCENT_DIVIDER = 100;

        private readonly ISkillSetModel<T> _pattern;

        public MatchingGetter(ISkillSetModel<T> pattern)
        {
            _pattern = pattern;
        }

        public int GetMatching(ISkillSetModel<T> skillSet)
        {
            double result = 1;

            if (_pattern.Skills.Count() != 0)
            {
                result = (double)_pattern.Skills
                    .Intersect(skillSet.Skills)
                    .Count() / _pattern.Skills.Count();
            }

            result *= PERCENT_DIVIDER;
            result = Math.Round(result, MidpointRounding.AwayFromZero);

            return (int)result;
        }
    }
}
