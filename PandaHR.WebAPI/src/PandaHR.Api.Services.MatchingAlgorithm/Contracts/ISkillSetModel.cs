using System.Collections.Generic;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillSetModel<Guid> : IBaseModel<Guid>
    {
        IEnumerable<Guid> Skills { get; set; }
    }
}
