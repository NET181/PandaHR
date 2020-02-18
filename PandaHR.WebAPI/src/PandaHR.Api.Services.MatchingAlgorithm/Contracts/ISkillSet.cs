using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillSetModel<Guid> : IBaseModel<Guid>
    {
        IEnumerable<Guid> Skills { get; set; }
    }
}
