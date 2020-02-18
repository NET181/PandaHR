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
    public class MongoDBServiceTest
    {
        private readonly HttpClient _client;

        public MongoDBServiceTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(@"TestPhotos\", "HelloWorld.docx")]
        public async Task UploadFileAsync(string filePath, string fileName)
        {
            // Arrange
            string Url = "api/File";
            // Act
            var response = await _client.PostAsync(Url, ContentHelper.GetFileContent(filePath, fileName));
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
