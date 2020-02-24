using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm.Models
{
    public class SkillSetWithRatingModel<T> : ISkillSetWithRatingModel<T>
    {
        public T Id { get; set; }
        public IEnumerable<T> Skills { get; set; }
        public int Rating { get; set; }
    }
}
