using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface IBaseModel<T>
    {
        T Id { get; set; }
    }
}
