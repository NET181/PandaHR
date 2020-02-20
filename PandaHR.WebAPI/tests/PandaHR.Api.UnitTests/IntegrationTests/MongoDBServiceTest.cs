using System;
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
                mpContent.Add(content, "uploadedFile", fileName);

                response = await _client.PostAsync(request.Url, mpContent);
            }
            
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("5e4efe35db02ea315c415671", @"_testFiles\", "HelloWorld.docx")]
        public async Task GetFileByIdCompare(string id, string expectedPath, string expectedFile)
        {
            var request = new
            {
                Url = "api/File/",
                Id = id
            };
            var url = String.Format($"{request.Url}{request.Id}");
            var response = await _client.GetAsync(url);

            byte[] actual = await response.Content.ReadAsByteArrayAsync();
            byte[] expected;
            using (var file = File.OpenRead(expectedPath + expectedFile))
            {
                expected = new byte[file.Length];
                await file.ReadAsync(expected);
            }

            // Assert
            Assert.Equal(expected, actual);
            response.EnsureSuccessStatusCode();
        }        
    }
}
