using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;

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
               
            };
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
        [InlineData(@"_testFiles\", "ToDelete.docx")]
        public async Task DeleteFileAsync(string filePath, string fileName)
        {
            // Arrange
            var request = new
            {
                Url = "api/File/Flow/",
                Id = new Guid("342f6c46-9bd1-4508-b1f7-6a8eed1ac270")
            };
            var url = String.Format($"{request.Url}{request.Id.ToString()}");
            HttpResponseMessage response;
            var mpContent = new MultipartFormDataContent();

            using (var file = File.OpenRead(filePath + fileName))
            using (var content = new StreamContent(file))
            {
                mpContent.Add(content, "uploadedFile", fileName);

                response = await _client.PostAsync(url, mpContent);
            }

            var value = await response.Content.ReadAsStringAsync();

            url = String.Format($"api/File/{value}");
            response = await _client.DeleteAsync(url);

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
