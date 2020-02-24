using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using PandaHR.Api.Services.MatchingAlgorithm.Contracts;

namespace PandaHR.Api.UnitTests.MatchingAlgorithmTests
{
    public class MatchingAlgorithmTests : IClassFixture<MatchingAlgorithmSeed>
    {
        private readonly IMatchingGetter<Guid> _matchingGetter;
        private readonly IReadOnlyList<ISkillSetWithRatingModel<Guid>> _skillSetModels;
        private readonly ISkillMatchingAlgorithm<Guid> _skillMatchingAlgorithm;

        public MatchingAlgorithmTests(MatchingAlgorithmSeed testSeed)
        {
            _matchingGetter = testSeed.GetMatcher();
            _skillMatchingAlgorithm = testSeed.GetAlgorithm();
            _skillSetModels = testSeed.GetSkillSetModels();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void CanGetMatching(int index)
        {
            //Act

            int expected = _skillSetModels[index].Rating;
            int result = _matchingGetter.GetMatching(_skillSetModels[index]);

            //Assert

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(32, 3)]
        [InlineData(66, 2)]
        [InlineData(99, 1)]
        public void CanFilterByThreshold(int treshold, int expected)
        {
            //Act

            int result = _skillMatchingAlgorithm
                .GetMatchingModels(
                _skillSetModels[0],
                _skillSetModels, 
                treshold,
                10)
                .Count();

            //Assert

            Assert.Equal(result, expected);
        }

        [Fact]
        public void ArgumentNullExceptionTest()
        {
            //Act

            Action action = () =>
            {
                _skillMatchingAlgorithm.GetMatchingModels(null, _skillSetModels, 0, 10);
            };

            //Assert

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
