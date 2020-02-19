using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm;
using PandaHR.Api.Models.IdAndRating;
using PandaHR.Api.Models.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;

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

        [HttpGet("GetVacancyByCV")]
        public async Task<IActionResult> GetVacanciesByCVSkillSet(Guid CVId, double threshold)
        {
            try
            {
                var result = await _vacancyService.GetVacanciesByCV(CVId, threshold);

                if (result.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (ArgumentNullException)
            {
                //log
                return NotFound(CVId);
            }
        }

        [HttpGet("searchfor/{id}")]
        public async Task<IActionResult> GetCVsByRaitingForVacancy(Guid id)
        {
            try
            {
                var some = await _scoreCounter.GetCVsByVacancy(id);

                var request = _mapper.Map<IEnumerable<IdAndRatingServiceModel>
                    , IEnumerable<IdAndRatingResponseModel>>(some);

                return Ok(request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("/getVacancySummary")]
        public async Task<IActionResult> GetUserCVsSummary(Guid userId, int page, int pageSize)
        {
            return Ok(await _vacancyService.GetVacancyPreviewAsync(userId, pageSize, page));
        }

        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetByCity(Guid id, int page = 1, int pageSize = 10)
        {
            var vacancies = await _vacancyService.GetByCity(id, pageSize, page);
           
            if (vacancies != null)
            {
                return Ok(vacancies);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetByCompany(Guid id, int page = 1, int pageSize = 10)
        {
            var vacancies = await _vacancyService.GetByCompany(id, pageSize, page);

            if (vacancies != null)
            {
                return Ok(vacancies);
            }
            else
            {
                return NotFound();
            }
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
