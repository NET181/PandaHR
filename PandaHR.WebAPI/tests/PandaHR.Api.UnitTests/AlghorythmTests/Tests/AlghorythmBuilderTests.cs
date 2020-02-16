using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.AlghorythmTests.Tests
{
    public class AlghorythmBuilderTests : IClassFixture<AlghorythmTestSeed>
    {
        private AlghorythmTestSeed _testSeed;

        public AlghorythmBuilderTests(AlghorythmTestSeed testSeed)
        {
            _testSeed = testSeed;
        }

    }
}
