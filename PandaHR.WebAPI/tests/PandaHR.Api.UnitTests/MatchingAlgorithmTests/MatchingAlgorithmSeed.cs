using PandaHR.Api.Services.MatchingAlgorithm.Contracts;
using PandaHR.Api.Services.MatchingAlgorithm.Implementation;
using PandaHR.Api.Services.MatchingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.UnitTests.MatchingAlgorithmTests
{
    public class MatchingAlgorithmSeed
    {
        private readonly IReadOnlyList<ISkillSetWithRatingModel<Guid>> _models
            = new List<ISkillSetWithRatingModel<Guid>>
            {
                new SkillSetWithRatingModel<Guid>
                {
                    Id = new Guid(),
                    Skills = new Guid[]
                    {
                        new Guid("28EFAAE8-61A4-4A26-B5F0-673E507FA27B"),
                        new Guid("CA0E270A-33EC-47F1-BF39-A9804C72E4A8"),
                        new Guid("47BBA59E-F3F6-4A59-BC69-F25A06F3C8CD"),
                    },
                    Rating = 100
                },

                new SkillSetWithRatingModel<Guid>
                {
                    Id = new Guid(),
                    Skills = new Guid[]
                    {
                        new Guid(),
                        new Guid("CA0E270A-33EC-47F1-BF39-A9804C72E4A8"),
                        new Guid("47BBA59E-F3F6-4A59-BC69-F25A06F3C8CD"),
                    },
                    Rating = 67
                },

                new SkillSetWithRatingModel<Guid>
                {
                    Id = new Guid(),
                    Skills = new Guid[]
                    {
                        new Guid(),
                        new Guid(),
                        new Guid("47BBA59E-F3F6-4A59-BC69-F25A06F3C8CD"),
                    },
                    Rating = 33
                },

                new SkillSetWithRatingModel<Guid>
                {
                    Id = new Guid(),
                    Skills = new Guid[]
                    {
                        new Guid(),
                        new Guid(),
                        new Guid(),
                    },
                    Rating = 0
                }
            };
        public IReadOnlyList<ISkillSetWithRatingModel<Guid>> GetSkillSetModels()
        {
            return _models.ToList();
        }

        public IMatchingGetter<Guid> GetMatcher()
        {
            return new MatchingGetter<Guid>(_models[0]);
        }

        public ISkillMatchingAlgorithm<Guid> GetAlgorithm()
        {
            return new SkillMatchingAlgorithm<Guid>();
        }

    }
}
