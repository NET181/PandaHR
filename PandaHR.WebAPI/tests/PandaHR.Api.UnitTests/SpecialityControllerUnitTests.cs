using PandaHR.Api.DAL.Models.Entities;
using System;
using Xunit;
using Moq;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PandaHR.Api.UnitTests
{
    public class SpecialityControllerUnitTests
    {
        [Fact]
        public void GetItemById_ReturnsOk()
        {
            var speciality = new Speciality
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "NewSpeciality"
            };

            var mock = new Mock<ISpecialityService>();

            mock.Setup(v => v.GetByIdAsync(speciality.Id)).ReturnsAsync(speciality);

            var controller = new SpecialityController(mock.Object);

            var actual = controller.Get(speciality.Id).Result as ObjectResult;

            Assert.NotNull(actual);
            Assert.Equal(new OkResult().StatusCode, actual.StatusCode);
        }

        [Fact]
        public void GetItemById_ReturnsNull()
        {
            Guid someId = new Guid("11111111-1111-1111-1111-111111111112");

            var speciality = new Speciality
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "NewSpeciality"
            };

            var mock = new Mock<ISpecialityService>();

            mock.Setup(v => v.GetByIdAsync(speciality.Id)).ReturnsAsync(speciality);

            var controller = new SpecialityController(mock.Object);

            var actual = controller.Get(someId).Result as ObjectResult;

            Assert.Null(actual);
        }
    }
}
