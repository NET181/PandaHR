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

        public VacancyController(IVacancyService vacancyService
            , IScoreCounter scoreCounter, IMapper mapper
            , ISkillService skillService)
        {
            _vacancyService = vacancyService;
            _scoreCounter = scoreCounter;
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("{threshold}/{skillNames}")]
        public async Task<IEnumerable<Vacancy>> GetCVsBySkills(
            [FromRoute]string[] skillNames, double threshold)
        {
            skillNames = skillNames[0].Split(",");

            var findedSkills = new List<SkillNameServiceModel>();
            var skills = await _skillService.GetSkillNames();

            foreach (var skill in skills)
            {
                foreach (var skillName in skillNames)
                {
                    if (skill.Name == skillName)
                    {
                        findedSkills.Add(skill);
                    }
                }
            }
            var algorithmSkills = _mapper.Map<IEnumerable<SkillNameServiceModel>, IEnumerable<Skill>>(findedSkills);

            return await _vacancyService.GetBySkillSet(algorithmSkills, threshold);
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
