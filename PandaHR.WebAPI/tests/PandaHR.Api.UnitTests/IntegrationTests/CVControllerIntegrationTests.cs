using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Models.User;
using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using PandaHR.Api.UnitTests.IntegrationTests;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests
{
    public class CVControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CVControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetUserInfo_SuccessStatusCode()
        {
            // Arrange
            var request = new
            {
                Url = "api/User/",
                Id = new Guid("b072e561-9258-4502-8b40-c545b121cb0c")
            };
            var url = String.Format($"{request.Url}{request.Id.ToString()}");
            // Act
            var response = await _client.GetAsync(url);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<UserResponseModel>(stringResponse);
            // Assert
            Assert.Equal(userInfo.Id, request.Id);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PostCV_SuccessStatusCode()
        {
            CVCreationRequestModel cv = GetCorrectCVCreationRequestModel();
            // Arrange
            var request = new
            {
                Url = "api/CV",
                Body = cv
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PostCV_InCorrectEmail_BadRequest()
        {
            // Arrange
            CVCreationRequestModel cv = GetCorrectCVCreationRequestModel();
            cv.User.Email = "aaaaaamail.ru";
            var request = new
            {
                Url = "api/CV",
                Body = cv
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("Email is required", value);
        }

        [Theory]
        [InlineData("test@gmail.com", null)]
        [InlineData(null, "1234567890")]
        public async Task PostCV_EmailIsNull_Or_PhoneIsNull_SuccessRequest(string email, string phone)
        {
            // Arrange
            CVCreationRequestModel cv = GetCorrectCVCreationRequestModel();
            cv.User.Email = email;
            cv.User.Phone = phone;
            var request = new
            {
                Url = "api/CV",
                Body = cv
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostCV_EmailIsNull_PhoneIsNull_BadRequest()
        {
            // Arrange
            CVCreationRequestModel cv = GetCorrectCVCreationRequestModel();
            cv.User.Email = null;
            cv.User.Phone = null;
            var request = new
            {
                Url = "api/CV",
                Body = cv
            };
            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private CVCreationRequestModel GetCorrectCVCreationRequestModel()
        {
            CVCreationRequestModel cv = new CVCreationRequestModel
            {
                User = new UserCreationServiceModel()
                {
                    FirstName = "timuuuuuuur8",
                    SecondName = "mirzaieeeeeeeeeev",
                    Email = "asfafssafasf8@gmail.com",
                    Phone = "1234512345"
                },
                Educations = new Collection<EducationWithDetailsServiceModel>()
                    {
                        new EducationWithDetailsServiceModel()
                        {
                            DegreeId = new Guid("a76428b1-aac5-410b-af4f-811c9b474997")
                        }
                    },
                QualificationId = new Guid("a76428b1-aac5-410b-af4f-811c9b474997"),
                TechnologyId = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e"),
                SkillKnowledges = new Collection<SkillKnowledgeServiceModel>() {
                        new SkillKnowledgeServiceModel()
                        {
                            ExperienceId = new Guid("561d468e-a93b-4e6b-a576-52b3d7bbf32a"),
                            KnowledgeLevelId = new Guid("2cb573c8-c593-445a-a1ca-d072fba8b47e"),
                            SkillId = new Guid("b072e511-9258-4502-8b40-c545b121cb0c")
                        }
                    }
            };

            return cv;
        }
    }
}
