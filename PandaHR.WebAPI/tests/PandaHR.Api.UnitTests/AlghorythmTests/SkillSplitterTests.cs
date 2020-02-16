using PandaHR.Api.Services.ScoreAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using Xunit;
using System.Threading.Tasks;

namespace PandaHR.Api.UnitTests.AlghorythmTests.Tests
{
    public class SkillSplitterTests : IClassFixture<AlghorythmTestSeed>
    {
        private readonly AlghorythmTestSeed _testSeed;
        private readonly SkillSplitter _skillSplitter;
        

        public SkillSplitterTests(AlghorythmTestSeed testSeed)
        {
            _skillSplitter = testSeed.SkillSplitter;
            _testSeed = testSeed;
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 2)]
        [InlineData(50, 3)]
        public void SplitSkillsByTypeMainSkillsTest(int middleWeight, int mainSkillCount)
        {
            //Arrange
            var skillRequests = new List<SkillRequestAlghorythmModel>(_testSeed.SkillRequests);

            //Act
            var splitedSkillsTest = _skillSplitter.SplitSkills(skillRequests, middleWeight);

            //Assert 
            Assert.Equal(mainSkillCount, splitedSkillsTest.MainSkills.Count);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(25, 1)]
        [InlineData(40, 0)]
        public void SplitSkillsByTypeHardSkillsTest(int middleWeight, int hardSkillCount)
        {
            //Arrange
            var skillRequests = new List<SkillRequestAlghorythmModel>(_testSeed.SkillRequests);

            //Act
            var splitedSkillsTest = _skillSplitter.SplitSkills(skillRequests, middleWeight);

            //Assert 
            Assert.Equal(hardSkillCount, splitedSkillsTest.HardSkills.Count);
        }

        [Fact]
        public void SplitSkillsByTypeSoftSkillsTest()
        {
            //Arrange
            var skillRequests = new List<SkillRequestAlghorythmModel>(_testSeed.SkillRequests);
            int middleWeight = 10;
            int softSkillCount = 2;

            //Act
            var splitedSkillsTest = _skillSplitter.SplitSkills(skillRequests, middleWeight);

            //Assert 
            Assert.Equal(softSkillCount, splitedSkillsTest.SoftSkills.Count);
        }


        [Fact]
        public void SplitSkillsByTypeLangSkillsTest()
        {
            //Arrange
            var skillRequests = new List<SkillRequestAlghorythmModel>(_testSeed.SkillRequests);
            int middleWeight = 10;
            int langSkillCount = 1;

            //Act
            var splitedSkillsTest = _skillSplitter.SplitSkills(skillRequests, middleWeight);

            //Assert 
            Assert.Equal(langSkillCount, splitedSkillsTest.LangSkills.Count);
        }
    }
}

