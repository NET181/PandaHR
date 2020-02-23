using Microsoft.AspNetCore.Mvc;
using Moq;
using PandaHR.Api.Common;
using PandaHR.Api.Controllers;
using PandaHR.Api.DAL.DTOs.Vacancy;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PandaHR.Api.UnitTests.UnitTests
{
    public class VacancyControllerUnitTest
    {
        private readonly PandaHRAutoMapper _mapper = new PandaHRAutoMapper();

        //mock _scoreCounter GetCVsByVacancy
        //mock _vacancyService GetVacancyPreviewAsync

        [Fact]
        public async void GetUserCVsSummary_ReturnsOk()
        {
            //arrange
            var vacanciesPreview = new VacancySummaryDTO[]
            {
                new VacancySummaryDTO() { Id = new Guid("11111111-1111-1111-1111-111111111111") },
                new VacancySummaryDTO() { Id = new Guid("11111111-1111-1111-1111-111111111112") }
            };
            var mock = new Mock<IVacancyService>();
            mock.Setup(v => v.GetVacancyPreviewAsync(It.IsAny<Guid>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                .ReturnsAsync(vacanciesPreview);
            VacancyController vacancyController = new VacancyController(mock.Object, null, _mapper, null);
            //act
            ObjectResult actual = vacancyController.GetUserCVsSummary(
                new Guid("11111111-1111-1111-1111-111111111110"), 1, 1).Result as ObjectResult;
            var actualVacancies = actual.Value as IEnumerable<VacancySummaryDTO>;
            //assert
            Assert.Equal(200, actual.StatusCode);
            Assert.Equal(vacanciesPreview, actualVacancies);
        }

        [Fact]
        public void GetCVsByRaitingForVacancy_ReturnsOk()
        {
            //arrange
           /* 
            * var vacanciesPreview = new VacancySummaryDTO[]
            {
                new VacancySummaryDTO() { Id = new Guid("11111111-1111-1111-1111-111111111111") },
                new VacancySummaryDTO() { Id = new Guid("11111111-1111-1111-1111-111111111112") }
            };
            var mock = new Mock<IScoreCounter>();
            mock.Setup(v => v.GetCVsByVacancy(It.IsAny<Guid>()))
                .ReturnsAsync(vacanciesPreview);
            VacancyController vacancyController = new VacancyController(mock.Object, null, _mapper, null);
            //act
            ObjectResult actual = vacancyController.GetUserCVsSummary(
                new Guid("11111111-1111-1111-1111-111111111110"), 1, 1).Result as ObjectResult;
            var actualVacancies = actual.Value as IEnumerable<VacancySummaryDTO>;
            //assert
            Assert.Equal(200, actual.StatusCode);
            Assert.Equal(vacanciesPreview, actualVacancies);
            */
        }

        [Fact]
        public void GetUserCVsSummary_ReturnsNotFound()
        {

        }
    }
}
