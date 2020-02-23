using PandaHR.Api.Models.VacancyCVFlow;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public class VacancyCVFlowControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public VacancyCVFlowControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async void VacancyCVFlow_Post_IsCorrect()
        {
            VacancyCVFlowCreationRequestModel vacancyCVFlow = GetCorrectVacancyCVFlowCreationRequestModel();
            // Arrange
            var request = new
            {
                Url = "api/VacancyCVFlow",
                Body = vacancyCVFlow
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode();
        }

        private VacancyCVFlowCreationRequestModel GetCorrectVacancyCVFlowCreationRequestModel()
        {
            VacancyCVFlowCreationRequestModel vacancyCVFlow = new VacancyCVFlowCreationRequestModel()
            {
                CVId = new Guid("a6a7e31d-3db1-45b6-8172-3ad5556f65ce"),
                Notes = "test",
                Status = DAL.Models.Entities.Enums.VacancyCVStatus.Draft,
                VacancyId = new Guid("623af0cf-21c1-4dc6-8f86-09601e9dba86")
            };

            return vacancyCVFlow;
        }
    }
}