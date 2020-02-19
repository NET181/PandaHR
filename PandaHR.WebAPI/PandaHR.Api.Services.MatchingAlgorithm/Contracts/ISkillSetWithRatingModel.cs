using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillSetWithRatingModel<T> : ISkillSetModel<T>
    {
        public double Rating { get; set; }
    }
}
