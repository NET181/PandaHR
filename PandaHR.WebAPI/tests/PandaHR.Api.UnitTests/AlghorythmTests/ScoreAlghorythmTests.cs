using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.UnitTests.AlghorythmTests.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.AlghorythmTests
{
    public class ScoreAlghorythmTests : IClassFixture<AlghorythmTestSeed>
    {
        private readonly AlghorythmTestSeed _testSeed;
        private readonly ScoreAlghorythm _alghorythm;

        public ScoreAlghorythmTests(AlghorythmTestSeed testSeed)
        {
            _testSeed = testSeed;
            _alghorythm = testSeed.Alghorythm;
        }

        [Fact]
        public void CountRationTest()
        {
            //Arrange
            int expected = 286;
            int actual;

            //Act

            actual = _alghorythm.GetRating(_testSeed.Vacancy, _testSeed.CV);

            //Assert 
            Assert.Equal(expected, actual);
        }
    }
}
