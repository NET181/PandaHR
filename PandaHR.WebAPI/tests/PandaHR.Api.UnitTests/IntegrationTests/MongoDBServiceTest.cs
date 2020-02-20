using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using PandaHR.Api.DAL.MongoDB.Entities;

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
        //[InlineData("5e4da212a7aa6b3324aa8324")]
        [InlineData("5e4e11a633a1aa25e40e8b97")]
        public async Task GetFileByIdCompare(string id)
        {
            var request = new
            {
                Url = "api/File/",
                Id = id
            };
            var url = String.Format($"{request.Url}{request.Id.ToString()}");
            var response = await _client.GetAsync(url);
            var responseBody = await response.Content.ReadAsByteArrayAsync();
            // Assert

            SaveBinaryAsFile("HelloWorld.docx", responseBody);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllFiles()
        {
            var request = new
            {
                Url = "api/File/",
               
            };
            var url = String.Format($"{request.Url}");
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }

        private void SaveBinaryAsFile(string filename, byte[] data)
        {
            string Name = "/ExtractedFiles/" + filename;
            BinaryWriter Writer;
            
            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(Name));

                // Writer raw data                
                Writer.Write(data);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                //...

            }

            finally
            { }
            
        }
    }
}
