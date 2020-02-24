using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IMatchingGetter<T>
    {
        int GetMatching(ISkillSetModel<T> skillSet);
    }
}
