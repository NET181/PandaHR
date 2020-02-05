using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using PandaHR.Api.Models.Education;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public class QualificationControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public QualificationControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetEducations_AutofillByName_SuccessefullStatusAsync()
        {
            // Arrange
            var request = new
            {
                Url = "api/education/autofill/",
                Param = "dn"
            };
            var expected = "DNU";
            var url = String.Format($"{request.Url}{request.Param}");
            // Act
            var response = await _client.GetAsync(url);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var qualifications = JsonConvert
                .DeserializeObject<ICollection<EducationBasicInfoResponse>>(stringResponse);
            var actual = qualifications.FirstOrDefault();
            // Assert
            Assert.Equal(expected, actual.PlaceName);
            response.EnsureSuccessStatusCode();
        }
    }
}
