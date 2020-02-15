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

        public SkillSplitterTests(AlghorythmTestSeed testSeed)
        {
            _skillSplitter = testSeed.SkillSplitter;
        }

        [Fact]
        public void SplitSkillsByType()
        {
            _skillSplitter
                .SplitSkills(new List<SkillRequestAlghorythmModel>(_testSeed.SkillRequests), 0);
        }
    }
}

