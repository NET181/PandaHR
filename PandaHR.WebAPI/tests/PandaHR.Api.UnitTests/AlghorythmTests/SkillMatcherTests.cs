using PandaHR.Api.Services.ScoreAlgorithm;
using PandaHR.Api.Services.ScoreAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.AlghorythmTests.Tests
{
    public class SkillMatcherTests : IClassFixture<AlghorythmTestSeed>
    {
        private readonly SkillsMatcher _skillsMatcher;
        private readonly List<SkillKnowledgeAlghorythmModel> _skillKnowledge;
        private readonly SplitedSkillsAlghorythmModel _splitedSkills;

        public SkillMatcherTests(AlghorythmTestSeed testSeed)
        {
            _skillsMatcher = testSeed.SkillsMatcher;
            _skillKnowledge = testSeed.SkillKnowledge;
            _splitedSkills = testSeed.SplitedSkills;
        }

        [Fact]
        public void MathRootSkillsBySubTest()
        {
            //Arrange
            SplitedSkillsAlghorythmModel splitedSkills;
            List<SkillKnowledgeAlghorythmModel> skillKnowledgesTest = new List<SkillKnowledgeAlghorythmModel>(_skillKnowledge);

            //Act
            skillKnowledgesTest.RemoveAt(0); // remove .Net from knowledge
            splitedSkills = _skillsMatcher.MatchSkills(skillKnowledgesTest, _splitedSkills);

            //Assert 
            Assert.True(splitedSkills.MainSkills[0].SkillKnowledge != null);
        }

        [Fact]
        public void MathHardSkillsTest()
        {
            //Arrange
            SplitedSkillsAlghorythmModel splitedSkills;
            
            //Act
            splitedSkills = _skillsMatcher.MatchSkills(_skillKnowledge, _splitedSkills);

            //Assert 
            foreach (var skill in splitedSkills.HardSkills)
            {
                Assert.True(skill.SkillKnowledge != null);
            }
        }

        [Fact]
        public void MathSoftSkillsTest()
        {
            //Arrange
            SplitedSkillsAlghorythmModel splitedSkills;

            //Act
            splitedSkills = _skillsMatcher.MatchSkills(_skillKnowledge, _splitedSkills);

            //Assert 
            foreach (var skill in splitedSkills.SoftSkills)
            {
                Assert.True(skill.SkillKnowledge != null);
            }
        }

        [Fact]
        public void MathMainSkillsTest()
        {
            //Arrange
            SplitedSkillsAlghorythmModel splitedSkills;

            //Act
            splitedSkills = _skillsMatcher.MatchSkills(_skillKnowledge, _splitedSkills);

            //Assert 
            foreach (var skill in splitedSkills.MainSkills)
            {
                Assert.True(skill.SkillKnowledge != null);
            }
        }

        [Fact]
        public void MathLangSkillsTest()
        {
            //Arrange
            SplitedSkillsAlghorythmModel splitedSkills;

            //Act
            splitedSkills = _skillsMatcher.MatchSkills(_skillKnowledge, _splitedSkills);

            //Assert 
            foreach (var skill in splitedSkills.LangSkills)
            {
                Assert.True(skill.SkillKnowledge != null);
            }
        }
    }
}
