using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using PandaHR.Api.Validation.CV;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private IMapper _mapper;
        private readonly ICVService _cvService;
        private readonly ISkillService _skillService;

        public CVController(IMapper mapper, ICVService cvService, ISkillService skillService)
        {
            _mapper = mapper;
            _cvService = cvService;
            _skillService = skillService;
        }

        [HttpGet("{threshold}/{skillNames}")]
        public async Task<IEnumerable<CV>> GetCVsBySkills(
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

            return await _cvService.GetBySkillSet(algorithmSkills, threshold);
        }

        [HttpGet("/UserCVsExt")]
        public async Task<IActionResult> GetUserCVs(Guid userId, int page, int pageSize)
        {
            return Ok(await _cvService.GetUserCVsAsync(userId, pageSize, page));
        }

        [HttpGet("/UserCVsSummary")]
        public async Task<IActionResult> GetUserCVsSummary(Guid userId, int page, int pageSize)
        {
            return Ok(await _cvService.GetUserCVsPreviewAsync(userId, pageSize, page));
        }

        [HttpGet("/VacanciesForCV")]
        public async Task<IActionResult> GetVacanciesForCV(Guid CVId, int page, int pageSize)
        {
            return Ok(await _cvService.GetVacanciesForCV(CVId, pageSize, page));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                // await _cvService.RemoveAsync(id);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CV cv)
        {
            try
            {
                //  await _cvService.UpdateAsync(cv);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CVCreationRequestModel cv)
        {
            var cvServiceModel = _mapper.Map<CVCreationRequestModel, CVCreationServiceModel>(cv);
            await _cvService.AddAsync(cvServiceModel);
                
            return Ok();
        }
    }
}
