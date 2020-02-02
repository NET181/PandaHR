using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests
{
    public class ControllerTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ControllerTests(TestingWebAppFactory<Startup> factory)
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
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task HomePage_StatusCode200()
        {
            //arrange

            //act
            var response = await _client.GetAsync("swagger/index.html");
            //assert
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
