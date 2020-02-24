using Newtonsoft.Json;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.VacancyCVFlow;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests
{
    public class VacancyCVFlowIntergrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public VacancyCVFlowIntergrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("623af0cf-21c1-4dc6-8f86-09601e9dba86")]
        [InlineData("233af0cf-2451-42cq-8516-t9f01e9d1s86")]
        public async Task GetAllFlowsByVacancyId_ReturnEmptyBody(Guid vacancyId)
        {
            int lengthEmptyBody = 2;

            var request = new
            {
                Url = "api/VacancyCVFlow/GetAllFlowsByVacancyId/",
                Id = vacancyId
            };

            var url = String.Format($"{request.Url}{request.Id.ToString()}");

            var response = await _client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.Equal(lengthEmptyBody, responseBody.ToString().Length);
        }

        [Theory]
        [InlineData("a8c58938-2339-4466-b662-023be9e4e9a5")]
        [InlineData("aeed7aa1-78fa-427c-b2f8-30bbd08df1b5")]
        public async Task GetAllFlowsByVacancyId_ReturnOkStatusCode(Guid vacancyId)
        {
            var request = new
            {
                Url = "api/VacancyCVFlow/GetAllFlowsByVacancyId/",
                Id = vacancyId
            };

            var url = String.Format($"{request.Url}{request.Id.ToString()}");

            var response = await _client.GetAsync(url);
           
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
