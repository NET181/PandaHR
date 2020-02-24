using Moq;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Controllers;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Vacancy;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.Services.ScoreAlghorythm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PandaHR.Api.UnitTests.UnitTests
{
    public class VacancyUnitTests
    {
        private readonly Mock<IMapper> _mapper;
        private Mock<IVacancyService> _service;
        private Mock<IScoreCounter> _scoreCounter;

        public VacancyUnitTests()
        {
            _mapper = new Mock<IMapper>();
            _service = new Mock<IVacancyService>();
            _scoreCounter = new Mock<IScoreCounter>();
        }
        [Fact]
        public async Task AddVacancyCorrectResponce()
        {
            var requestModel = new VacancyCreationRequestModel()
            {
                CityId = new Guid("51896256-d235-4c42-e2ab-08d7af01e9b7"),
                CompanyId = new Guid("51896256-d235-4c42-e2ab-08d7af01e9b7"),
                QualificationId = new Guid("51896256-d235-4c42-e2ab-08d7af01e9b7"),
                TechnologyId = new Guid("51896256-d235-4c42-e2ab-08d7af01e9b7"),
                UserId = new Guid("51896256-d235-4c42-e2ab-08d7af01e9b7"),
                Description = "some description"
            };

            _service.Setup(s => s.AddAsync(MapVacancyServiceModel(requestModel)))
                .Returns(Task.FromResult(MapVacancyServiceModel(requestModel)));

            //Act

            var controller = new VacancyController(_mapper.Object, _service.Object);
            var result = await controller.AddSkillKnowledgeToCV(requestModel, GetCVId());

            var okResult = result as OkResult;

            //Assert 

            Assert.NotNull(okResult);
            Assert.Equal(new OkResult().StatusCode, okResult.StatusCode);
        }

        private VacancyServiceModel MapVacancyServiceModel(VacancyCreationRequestModel requestModel)
        {
            var vacancyServiceModel = new VacancyServiceModel()
            {
                CityId = requestModel.CityId,
                CompanyId = requestModel.CompanyId,
                QualificationId = requestModel.QualificationId,
                TechnologyId = requestModel.TechnologyId,
                UserId = requestModel.UserId,
                Description = requestModel.Description
            };

            return vacancyServiceModel;
        }
    }
}
