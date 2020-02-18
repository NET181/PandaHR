using Newtonsoft.Json;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PandaHR.Api.Models.Speciality;

namespace PandaHR.Api.UnitTests
{
    public class SpecialityControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SpecialityControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostSpeciality_StatusCode201()
        {
            var request = new
            {
                Url = "api/speciality",
                Body = new Speciality() { Name = "Programmer" }
            };

            var response = await _client.PostAsync(request.Url, ContentHelper
                .GetStringContent(request.Body));

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetSpecialityById_StatusCode200()
        {
            var request = new
            {
                Url = "api/speciality/",
                Id = new Guid("f98a7083-825c-496a-9112-ecd375a17dcb")
            };

            var url = String.Format($"{request.Url}{request.Id.ToString()}");

            var response = await _client.GetAsync(url);
 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetSpecialityById_StatusCode404()
        {
            var request = new
            {
                Url = "api/speciality/",
                Id = new Guid("f98a1083-825c-496a-9112-ecd375a17dcb")
            };

            var url = String.Format($"{request.Url}{request.Id.ToString()}");

            var response = await _client.GetAsync(url);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task DeleteSpecialityById_StatusCode204()
        {
            var request = new
            {
                Url = "api/speciality/",
                Id = new Guid("0d59cea4-85f5-4107-9d0f-8fecbe6a1933")
            };

            var url = String.Format($"{request.Url}{request.Id.ToString()}");

            var response = await _client.DeleteAsync(url);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }       
    }
}
