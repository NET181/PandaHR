using AutoFixture;
using Xunit;

namespace PandaHR.Api.UnitTests
{
    public class FakeTest
    {
        [Fact]
        public void Fake_test_1()
        {
            var fakeUsers = new Fixture();

            // Assert

            Assert.Equal(2, 1 + 1);
        }
    }
}
