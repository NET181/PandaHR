using Newtonsoft.Json;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Models.Entities.Enums;
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

        [Fact]
        public async void VacancyCVFlow_Patch_ChangeStatus_IsCorrect()
        {
            // Arrange
            var requestGetById = new
            {
                Url = "api/VacancyCVFlow",
                Id = new Guid("ad85fc0a-7f11-4d8f-9b3a-2b655658aaaf")
            };
            var urlGetById = String.Format($"{requestGetById.Url}/{requestGetById.Id.ToString()}");

            var requestPatch = new
            {
                Url = "api/VacancyCVFlow",
                Body = new VacancyCVFlowEditStatusRequestModel()
            };
            // Act
            var response = await _client.GetAsync(urlGetById);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var beforeFlow = JsonConvert.DeserializeObject<VacancyCVFlow>(stringResponse);
            var actualBeforeFlowStatus = beforeFlow.Status;

            beforeFlow.Status = VacancyCVStatus.Hired;
            await _client.PatchAsync(requestPatch.Url, ContentHelper.GetStringContent(beforeFlow));

            var actualResponse = await _client.GetAsync(urlGetById);
            var actualStringResponse = await actualResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<VacancyCVFlow>(actualStringResponse);
            // Assert
            Assert.Equal(actualBeforeFlowStatus, VacancyCVStatus.Draft);
            Assert.Equal(actual.Status, VacancyCVStatus.Hired);

            response.EnsureSuccessStatusCode();
        }

        private VacancyCVFlowCreationRequestModel GetCorrectVacancyCVFlowCreationRequestModel()
        {
            VacancyCVFlowCreationRequestModel vacancyCVFlow = new VacancyCVFlowCreationRequestModel()
            {
                CVId = new Guid("a6a7e31d-3db1-45b6-8172-3ad5556f65ce"),
                Notes = "test",
                VacancyId = new Guid("623af0cf-21c1-4dc6-8f86-09601e9dba86")
            };

            return vacancyCVFlow;
        }
    }
}