using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillContainer : IBaseModel
    {
        IEnumerable<Guid> SkillIds { get; set; }
    }
}
