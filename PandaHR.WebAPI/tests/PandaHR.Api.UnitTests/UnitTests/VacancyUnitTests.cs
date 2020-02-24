using Microsoft.AspNetCore.Mvc;
using Moq;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Controllers;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.SkillRequirement;
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
        private Mock<IVacancyService> _vacancyService;
        private Mock<ISkillService> _skillService;
        private Mock<IScoreCounter> _scoreCounter;

        public VacancyUnitTests()
        {
            _mapper = new Mock<IMapper>();
            _vacancyService = new Mock<IVacancyService>();
            _skillService = new Mock<ISkillService>();
            _scoreCounter = new Mock<IScoreCounter>();
        }
        //[Fact]
        //public async Task AddVacancyNotValidModel()
        //{
        //    var requestModel = new VacancyCreationRequestModel()
        //    {
        //        CityId = new Guid("639619FF-8B86-D011-B42D-00CF4FC964FF"),
        //        CompanyId = new Guid("D7470EDF-0F45-4715-2D53-08D7B914B13C"),
        //        QualificationId = new Guid("6015F293-A102-459B-9FA3-2CE7CC92C386"),
        //        TechnologyId = new Guid("F43F4B05-6CB1-4C72-9EBB-1FE5FD1FC62E"),
        //        UserId = new Guid("D2E34494-2A44-4C0D-A09B-4CC9849E4E97"),
        //        Description = "some description",
        //        Id = new Guid("D2E34494-2A44-4C0D-A09B-4CC9849E4E92"),
        //    };

        //    _vacancyService.Setup(s => s.AddAsync(MapVacancyServiceModel(requestModel)))
        //        .Returns(Task.FromResult(requestModel));

        //    //Act

        //    var controller = new VacancyController(_vacancyService.Object, _scoreCounter.Object, _mapper.Object, _skillService.Object);
        //    var result = await controller.AddVacancy(requestModel);

        //    var okResult = result as OkResult;

        //    //Assert 

        //    Assert.Equal(new OkResult().StatusCode, okResult.StatusCode);
        //}

        //private VacancyServiceModel MapVacancyServiceModel(VacancyCreationRequestModel requestModel)
        //{
        //    var vacancyServiceModel = new VacancyServiceModel()
        //    {
        //        CityId = requestModel.CityId,
        //        CompanyId = requestModel.CompanyId,
        //        QualificationId = requestModel.QualificationId,
        //        TechnologyId = requestModel.TechnologyId,
        //        UserId = requestModel.UserId,
        //        Description = requestModel.Description,
        //        Id = requestModel.Id
        //    };

        //    return vacancyServiceModel;
        //}
    }
}
