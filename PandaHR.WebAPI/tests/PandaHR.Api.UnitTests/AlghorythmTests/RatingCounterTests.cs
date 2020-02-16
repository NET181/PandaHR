using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.AlghorythmTests.Tests
{
    public class RatingCounterTests : IClassFixture<AlghorythmTestSeed>
    {
        private readonly RatingCounter _ratingCounter;
        private readonly CVAlghorythmModel _cV;
        private readonly VacancyAlghorythmModel _vacancy;
        private readonly SplitedSkillsAlghorythmModel _splitedSkills;


        public RatingCounterTests(AlghorythmTestSeed testSeed)
        {
            _ratingCounter = testSeed.RatingCounter;
            _cV = testSeed.CV;
            _vacancy = testSeed.Vacancy;
            _splitedSkills = testSeed.SkillsMatcher.MatchSkills(testSeed.SkillKnowledge, testSeed.SplitedSkills);
        }

        [Fact]
        public void CountRatingWithAllSkillsTest()
        {
            //Arrange
            int rating;
            int result = 386;
            int middleWeight = 30;

            //Act
            rating = _ratingCounter.CountRating(_splitedSkills, _cV, _vacancy, middleWeight);

            //Assert 
            Assert.Equal(result, rating);
        }

        [Fact]
        public void CountRatingWithoutMainSkillTest()
        {
            //Arrange
            int rating;
            int result = 198;
            int middleWeight = 30;

            var newSplitedSkills = new SplitedSkillsAlghorythmModel();
            newSplitedSkills.HardSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.HardSkills);
            newSplitedSkills.LangSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.LangSkills);
            newSplitedSkills.MainSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.MainSkills);
            newSplitedSkills.SoftSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.SoftSkills);

            //Act
            newSplitedSkills.MainSkills[0].SkillKnowledge = null;
            rating = _ratingCounter.CountRating(newSplitedSkills, _cV, _vacancy, middleWeight);

            //Assert 
            Assert.Equal(result, rating);
        }

        [Fact]
        public void CountRatingWithoutHardSkillTest()
        {
            //Arrange
            int rating;
            int result = 316;
            int middleWeight = 30;

            var newSplitedSkills = new SplitedSkillsAlghorythmModel();
            newSplitedSkills.HardSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.HardSkills);
            newSplitedSkills.LangSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.LangSkills);
            newSplitedSkills.MainSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.MainSkills);
            newSplitedSkills.SoftSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.SoftSkills);

            //Act
            newSplitedSkills.HardSkills[0].SkillKnowledge = null;
            rating = _ratingCounter.CountRating(newSplitedSkills, _cV, _vacancy, middleWeight);

            //Assert 
            Assert.Equal(result, rating);
        }

        [Fact]
        public void RatingDependensyBySkillWeigthTest()
        {
            //Arrange
            int firstWeigth = 40;
            int secondWeigth = 80;
            int firstRating = 0;
            int secondRating = 0;
            int middleWeight = 30;

            var newSplitedSkills = new SplitedSkillsAlghorythmModel();
            newSplitedSkills.HardSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.HardSkills);
            newSplitedSkills.LangSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.LangSkills);
            newSplitedSkills.MainSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.MainSkills);
            newSplitedSkills.SoftSkills = new List<SkillRequestSkillKnowledge>(_splitedSkills.SoftSkills);

            //Act
            newSplitedSkills.HardSkills[0].SkillRequirement.Weight = firstWeigth;
            firstRating = _ratingCounter.CountRating(newSplitedSkills, _cV, _vacancy, middleWeight);

            newSplitedSkills.HardSkills[0].SkillRequirement.Weight = secondWeigth;
            secondRating = _ratingCounter.CountRating(newSplitedSkills, _cV, _vacancy, middleWeight);

            //Assert 
            Assert.True(secondRating > firstRating);
        }
    }
}
