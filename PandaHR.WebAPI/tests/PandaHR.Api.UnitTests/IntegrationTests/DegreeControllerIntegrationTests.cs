using Newtonsoft.Json;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public class DegreeControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public DegreeControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async void PostDegree_StatusCodeIs201()
        {
            // Arrange
            var request = new
            {
                Url = "api/degree",
                Body = new Degree()
                {
                    Name = "topmanager",
                }
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var stringResponse = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}