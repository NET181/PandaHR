using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests
{
    public class ControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PageIsNotFound_IsOk()
        {
            //arrange

            //act
            var response = await _client.GetAsync("/");
            //assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task HomePage_StatusCode200()
        {
            //arrange

            //act
            var response = await _client.GetAsync("swagger/index.html");
            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
