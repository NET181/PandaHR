using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IMatchingModel<T> : IBaseModel
    {
        IEnumerable<T> MatchingSet { get; set; }
    }
}
