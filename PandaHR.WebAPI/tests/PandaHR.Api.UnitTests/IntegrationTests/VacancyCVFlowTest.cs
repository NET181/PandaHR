using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public class VacancyCVFlowTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public VacancyCVFlowTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(
            "a6a7e31d-3db1-45b6-8172-3ad5556f65ce",
            "623af0cf-21c1-4dc6-8f86-09601e9dba86",
            "Draft")]
        [InlineData(
            "b072e561-9258-4502-8b40-c545b121cb0c",
            "a8c58938-2339-4466-b662-023be9e4e9a5",
            "NotExists")]
        public async Task GetStatusTest(Guid CVId, Guid vacancyId, string expectedStatus)
        {
            // Arrange
            var request = new
            {
                Url = "Status",
                cv = CVId,
                vacancy = vacancyId
            };
            
            // Act
            string url = String.Format("{0}?CVId={1}&vacancyId={2}", request.Url, request.cv, request.vacancy);
            var response = await _client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal(expectedStatus, responseBody);
        }
    }
}
