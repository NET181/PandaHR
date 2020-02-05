using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using PandaHR.Api.Models.Company;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public class CompanyControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CompanyControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCompanies_AutofillByName_SuccessefullStatusAsync()
        {
            // Arrange
            var request = new
            {
                Url = "api/company/autofill/",
                Param = "sErVe"
            };
            var expected = "SoftServe";
            var url = String.Format($"{request.Url}{request.Param}");
            // Act
            var response = await _client.GetAsync(url);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var companies = JsonConvert
                .DeserializeObject<ICollection<CompanyBasicInfoResponse>>(stringResponse);
            var actual = companies.FirstOrDefault();
            // Assert
            Assert.Equal(expected, actual.Name);

            response.EnsureSuccessStatusCode();
        }
    }
}
