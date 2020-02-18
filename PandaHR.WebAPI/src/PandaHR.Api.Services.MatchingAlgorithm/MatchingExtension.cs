using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm
{
    public static class MatchingExtension
    {
        public static double GetMatching<T>(
            this IEnumerable<ISkillSetModel<T>> pattern, 
            IEnumerable<ISkillSetModel<T>> sequenceToCompare)
        {
            double result = 1;

            if (pattern.Count() != 0)
            {
                result = (double)pattern
                    .Intersect(sequenceToCompare)
                    .Count() / pattern.Count();
            }

            return result;
        }
    }
}
