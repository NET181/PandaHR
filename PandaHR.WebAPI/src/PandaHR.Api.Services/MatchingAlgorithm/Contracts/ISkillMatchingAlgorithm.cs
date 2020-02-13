﻿using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Contracts
{
    public interface ISkillMatchingAlgorithm
    {
        public IEnumerable<MatchingAlgorithmResponceModel> GetMatchingModels(
            ISkillContainer pattern,
            IEnumerable<ISkillContainer> matchingItems, 
            double threshold);
    }
}

