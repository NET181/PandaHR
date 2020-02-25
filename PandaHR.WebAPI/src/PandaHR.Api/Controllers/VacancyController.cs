using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.ScoreAlghorythm;
using PandaHR.Api.Services.ScoreAlghorythm.Models;
using PandaHR.Api.Models.IdAndRating;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Skill;
using PandaHR.Api.Validation.Vacancy;
using PandaHR.Api.Models.Vacancy;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.DAL;
using System.Linq;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IScoreCounter _scoreCounter;
        private readonly IMapper _mapper;
        private readonly ISkillService _skillService;
        private readonly VacancyValidator _validator;

        public VacancyController(IVacancyService vacancyService
            , IScoreCounter scoreCounter, IMapper mapper
            , ISkillService skillService)
        {
            _vacancyService = vacancyService;
            _scoreCounter = scoreCounter;
            _skillService = skillService;
            _mapper = mapper;
            _validator = new VacancyValidator();
        }

        [HttpGet("/GetVacanciesByCV/{CVId}/threshold={threshold}")]
        public async Task<IActionResult> GetVacanciesByCVSkillSet(Guid CVId, int threshold)
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

                var request = _mapper.Map<IEnumerable<AlghorythmResponseServiceModel>
                    , IEnumerable<AlghorythmResponseModel>>(some);

                return Ok(request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("/getVacancySummary")]
        public async Task<IActionResult> GetVacancySummary(Guid userId, int page = 1, int pageSize = 10)
        {
            return Ok(await _vacancyService.GetVacancyPreviewAsync(userId, page, pageSize));
        }

        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetByCity(Guid id, int page = 1, int pageSize = 10)
        {
            var vacancies = await _vacancyService.GetByCity(id, page, pageSize);
           
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
            var vacancies = await _vacancyService.GetByCompany(id, page, pageSize);

            if (vacancies != null)
            {
                return Ok(vacancies);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("/AddVacancy")]
        public async Task<IActionResult> AddVacancy([FromBody]VacancyCreationRequestModel model)
        {
            if (_validator.Validate(model).IsValid)
            {
                var mappedModel = _mapper.Map<VacancyCreationRequestModel, VacancyServiceModel>(model);
                await _vacancyService.AddAsync(mappedModel);

                return Ok(model);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpPut("/UpdateCV/{Id}")]
        public async Task<IActionResult> UpdateVacancy([FromBody]VacancyCreationRequestModel model, Guid Id)
        {
            if (_validator.Validate(model).IsValid)
            {
                var mappedModel = _mapper.Map<VacancyCreationRequestModel, VacancyServiceModel>(model);
                await _vacancyService.UpdateAsync(mappedModel);

                return Ok(mappedModel);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("/Vacancies/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _vacancyService.GetByIdAsync(id));
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("/Vacancies")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                ICollection<Vacancy> vacancies = await _vacancyService.GetAllAsync();

                return Ok(vacancies);
            }
            catch 
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("/Vacancies/{id}/delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(_vacancyService.RemoveAsync(id));
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}
