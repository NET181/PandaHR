using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
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

        [HttpGet("GetVacancyByCV")]
        public async Task<IActionResult> GetCVsBySkills(Guid CVId, double threshold)
        {
            try
            {
                var result = await _vacancyService.GetByCV(CVId, threshold);

                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound(CVId);
            };
        }

        [HttpGet("searchfor/{id}")]
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

        [HttpGet("/getVacancySummary")]
        public async Task<IActionResult> GetUserCVsSummary(Guid userId, int page, int pageSize)
        {
            return Ok(await _vacancyService.GetVacancyPreviewAsync(userId, pageSize, page));
        }
    }
}
