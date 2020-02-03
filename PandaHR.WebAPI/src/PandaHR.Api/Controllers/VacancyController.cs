using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Models.Vacancy;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.SkillRequirement;
using PandaHR.Api.Services.Models.Vacancy;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVacancy(VacancyCreationRequestModel vacancy)
        {
            var vacancyServiceModel = _mapper.Map<VacancyCreationRequestModel, VacancyServiceModel>(vacancy);
            await _vacancyService.AddAsync(vacancyServiceModel);

            return Ok();
        }
    }
}
