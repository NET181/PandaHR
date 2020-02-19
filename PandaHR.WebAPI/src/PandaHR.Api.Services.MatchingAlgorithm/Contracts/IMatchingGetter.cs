using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IMatchingGetter<T>
    {
        ISkillSetModel<T> Pattern { get; set;}
        double GetMatching(ISkillSetModel<T> skillSet);
    }
}
