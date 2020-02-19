using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Implementation
{
    public class MatchingGetter<T> : IMatchingGetter<T>
    {
        public ISkillSetModel<T> Pattern { get; set; }

        public double GetMatching(ISkillSetModel<T> skillSet)
        {
            double result = 1;

            if (Pattern.Skills.Count() != 0)
            {
                result = (double)Pattern.Skills
                    .Intersect(skillSet.Skills)
                    .Count() / Pattern.Skills.Count();
            }

            return result;
        }
    }
}
