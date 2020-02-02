using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IScoreCounter _scoreCounter;

        public VacancyController(IVacancyService vacancyService, IScoreCounter scoreCounter)
        {
            _vacancyService = vacancyService;
            _scoreCounter = scoreCounter;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCVsByRaitingForVacancy(int Id )
        {
            try
            {
                var some = await _scoreCounter.GetCVsByVacancy(new Guid());

                string a = "";
                foreach (var item in some)
                {
                    a += $"{item.Raiting}  ";
                }
                return Ok(some);
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
