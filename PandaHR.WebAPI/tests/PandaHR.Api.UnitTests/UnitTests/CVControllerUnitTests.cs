using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Controllers;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Implementation;
using PandaHR.Api.Mapper;
using PandaHR.Api.Models.JobExperience;
using PandaHR.Api.Models.SkillKnowledge;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Implementation;
using PandaHR.Api.Services.Models.Experience;
using PandaHR.Api.Services.Models.JobExperience;
using PandaHR.Api.Services.Models.SkillKnowledge;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests.UnitTests
{
    public class CVControllerUnitTests
    {
        private readonly Mock<IMapper> _mapper;
        private Mock<ICVService> _service;
        private Mock<IWebHostEnvironment> _env;

        public CVControllerUnitTests()
        {
            _mapper = new Mock<IMapper>();
            _env = new Mock<IWebHostEnvironment>();
            //_service = new Mock<ICVService>();
        }

        [Fact]
        public async Task AdditionSkillKnowledgeOkResponceAsync()
        {
            //Arrange
            var requestModel = new SkillKnowledgeRequestModel()
            {
                ExperienceId = new Guid("561d468e-a93b-4e6b-a576-52b3d7bbf32a"),
                SkillId = new Guid("b072e511-9258-4502-8b40-c545b121cb0c"),
                KnowledgeLevelId = new Guid("51896256-d235-4c42-e2ab-08d7af01e9b7")
            };

            _service = new Mock<ICVService>();
            _service.Setup(s => s.AddSkillKnowledgeToCVAsync(CreateSkillKnowledge(requestModel), GetCVId()))
                .Returns(Task.FromResult(CreateSkillKnowledge(requestModel)));

            //Act

            var controller = new CVController(_mapper.Object, _service.Object, _env.Object);
            var result = await controller.AddSkillKnowledgeToCV(requestModel, GetCVId());

            var okResult = result as OkResult;

            //Assert 

            Assert.NotNull(okResult);
            Assert.Equal(new OkResult().StatusCode, okResult.StatusCode);
        }

        [Fact]
        public async Task AdditionJobExperienceOkResponceAsync()
        {
            //Arrange
            var requestModel = new JobExperienceRequestModel()
            {
                CompanyName = "Softserve",
                ProjectName = "Sports Store",
                Description = "Developing Sports store",
                StartDate = new DateTime(2016, 3, 23),
                FinishDate = new DateTime(2018, 5, 12)
            };

            _service = new Mock<ICVService>();
            _service.Setup(s => s.AddJobExperienceToCVAsync(CreateJobExperience(requestModel), GetCVId()))
                .Returns(Task.FromResult(CreateJobExperience(requestModel)));

            //Act

            var controller = new CVController(_mapper.Object, _service.Object, _env.Object);
            var result = await controller.AddJobExperienceToCV(requestModel, GetCVId());

            var okResult = result as OkResult;

            //Assert 

            Assert.NotNull(okResult);
            Assert.Equal(new OkResult().StatusCode, okResult.StatusCode);
        }

        [Fact]

        public async Task DeletingSkillKnowledgeFromCVAsync()
        {
            //Arrange

            _service = new Mock<ICVService>();
            _service.Setup(s => s.DeleteSkillKnowledgeFromCVAsync(GetSkillId(), GetCVId()))
                .Returns(Task.FromResult(GetSkillId()));

            //Act

            var controller = new CVController(_mapper.Object, _service.Object, _env.Object);
            var result = await controller.DeleteSkillKnowledgeFromCV(GetSkillId(), GetCVId());

            var okResult = result as OkResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(new OkResult().StatusCode, okResult.StatusCode);
        }

        [Fact]
        public async Task DeletingJobExperienceFromCVAsync()
        {
            //Arrange

            _service = new Mock<ICVService>();
            _service.Setup(s => s.DeleteJobExperienceFromCVAsync(GetJobExperienceId(), GetCVId()))
                .Returns(Task.FromResult(GetJobExperienceId()));

            //Act

            var controller = new CVController(_mapper.Object, _service.Object, _env.Object);
            var result = await controller.DeleteJobExperienceFromCV(GetJobExperienceId(), GetCVId());

            var okResult = result as OkResult;

            //Assert

            Assert.NotNull(okResult);
            Assert.Equal(new OkResult().StatusCode, okResult.StatusCode);
        }

        private JobExperienceServiceModel CreateJobExperience(JobExperienceRequestModel requestModel)
        {
            JobExperienceServiceModel model = new JobExperienceServiceModel()
            {
                CompanyName = requestModel.CompanyName,
                ProjectName = requestModel.ProjectName,
                Description = requestModel.Description,
                StartDate = requestModel.StartDate,
                FinishDate = requestModel.FinishDate
            };

            return model;
        }

        private SkillKnowledgeServiceModel CreateSkillKnowledge(SkillKnowledgeRequestModel requestModel)
        {
            SkillKnowledgeServiceModel model = new SkillKnowledgeServiceModel()
            {
                ExperienceId = requestModel.ExperienceId,
                SkillId = requestModel.SkillId,
                KnowledgeLevelId = requestModel.KnowledgeLevelId
            };

            return model;
        }

        //private SkillKnowledge GetSkillKnowledgeById 
         
        private Guid GetCVId()
        {
            return new Guid("df294b76-1973-46ea-469e-08d7af01e979");
        }
        private Guid GetSkillId()
        {
            return new Guid("B072E511-9258-4502-8B40-C545B121CB0C");
        }
        private Guid GetJobExperienceId()
        {
            return new Guid("C017C4AE-B67B-4F26-2D3F-08D7AF01E991");
        }

    }
}
