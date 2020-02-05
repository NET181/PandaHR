using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Models.Education;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.ObjectModel;
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
                Url = "api/User/"
            };
            // Act
            var id = new Guid("b072e561-9258-4502-8b40-c545b121cb0c");
            var url = String.Format($"{request.Url}{id.ToString()}");
            
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateCV_SuccessStatusCode()
        {
            // Arrange
            var request = new
            {
                Url = "/api/CV/"
            };
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(
                new CVCreationRequestModel()
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
                    SkillKnowledges = new Collection<SkillKnowledgeServiceModel>(){
                        new SkillKnowledgeServiceModel()
                    {
                        ExperienceId = new Guid("561d468e-a93b-4e6b-a576-52b3d7bbf32a"),
                        KnowledgeLevelId = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"),
                        SkillId = new Guid("503661d4-297f-4e3d-f1cb-08d7a67ce45d")
                    }
                    }
                }),
                Encoding.UTF8,
                "application/json");
            // Act
            var response = await _client.PostAsync(request.Url, stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
