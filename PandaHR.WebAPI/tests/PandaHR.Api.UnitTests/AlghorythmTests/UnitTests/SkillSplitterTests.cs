using PandaHR.Api.Services.ScoreAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using Xunit;
using System.Threading.Tasks;

namespace PandaHR.Api.UnitTests.AlghorythmTests.UnitTests
{
    public class SkillSplitterTests : IClassFixture<AlghorythmTestSeed>
    {
        private AlghorythmTestSeed _testSeed;
        private SkillSplitter _skillSplitter;
        private SplitedSkillsAlghorythmModel _splitedSkills;

        public SkillSplitterTests(AlghorythmTestSeed testSeed)
        {
            _skillSplitter = testSeed.SkillSplitter;
            _testSeed = testSeed;
            ConfigSplitedSkills();
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
            int softSkillCount = 1;

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

        private void ConfigSplitedSkills()
        {
            var hardSkills = new List<SkillRequestSkillKnowledge>();
            var langSkills = new List<SkillRequestSkillKnowledge>();
            var mainSkills = new List<SkillRequestSkillKnowledge>();
            var softSkills = new List<SkillRequestSkillKnowledge>();

            mainSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = _testSeed.DotNet,
                    Weight = 80
                }
            });
            mainSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = _testSeed.EntityFramework,
                    Weight = 75
                }
            });

            hardSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = _testSeed.ASPNetCore,
                    Weight = 45
                }
            });

            langSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = _testSeed.English,
                    Weight = 80
                }
            });

            softSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = _testSeed.Oratory,
                    Weight = 35
                }
            });
            softSkills.Add(new SkillRequestSkillKnowledge()
            {
                SkillRequirement = new SkillRequestAlghorythmModel()
                {
                    Skill = _testSeed.Friendliness,
                    Weight = 15
                }
            });

            _splitedSkills = new SplitedSkillsAlghorythmModel()
            {
                HardSkills = hardSkills,
                LangSkills = langSkills,
                MainSkills = mainSkills,
                SoftSkills = softSkills
            };
        }
    }
}

