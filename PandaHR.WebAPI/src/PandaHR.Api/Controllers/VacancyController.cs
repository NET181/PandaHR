using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using PandaHR.Api.Models.IdAndRating;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IScoreCounter _scoreCounter;
        private readonly IMapper _mapper;

        public VacancyController(IVacancyService vacancyService
            , IScoreCounter scoreCounter, IMapper mapper)
        {
            _vacancyService = vacancyService;
            _scoreCounter = scoreCounter;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCVsByRaitingForVacancy(Guid id)
        {
            try
            {
                var some = await _scoreCounter.GetCVsByVacancy(id);

                var request = _mapper.Map<IEnumerable<IdAndRating>
                    , IEnumerable<IdAndRatingResponseModel>>(some);

                return Ok(request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _vacancyService.GetAllAsync();

            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vacancy vacancy)
        {
            await _vacancyService.AddAsync(vacancy);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, Vacancy vacancy)
        {
            await _vacancyService.UpdateAsync(vacancy);

            return Ok();
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _vacancyService.RemoveAsync(id);

            return Ok();
        }
    }
}
