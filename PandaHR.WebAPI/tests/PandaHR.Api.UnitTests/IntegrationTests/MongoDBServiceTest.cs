using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public class MongoDBServiceTest: IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public MongoDBServiceTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(@"_testFiles\", "HelloWorld.docx")]
        public async Task UploadFileAsync(string filePath, string fileName)
        {
            // Arrange
            var request = new
            {
                Url = "api/File",
               // Id = new Guid("b072e561-9258-4502-8b40-c545b121cb0c")
            };
           // var url = String.Format($"{request.Url}{request.Id.ToString()}");
            HttpResponseMessage response;
            var mpContent = new MultipartFormDataContent();

            using (var file = File.OpenRead(filePath + fileName))
            using (var content = new StreamContent(file))
            {
                mpContent.Add(content, "files", fileName);

                response = await _client.PostAsync(request.Url, mpContent);
            }
            
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
