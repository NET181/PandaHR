using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using System.Collections.ObjectModel;
using PandaHR.Api.Models.SkillKnowledge;
using PandaHR.Api.Models.JobExperience;
using PandaHR.Api.Services.Models.JobExperience;
using System.Collections.Generic;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private IMapper _mapper;
        private readonly ICVService _cvService;

        public CVController(IMapper mapper, ICVService cvService)
        {
            _mapper = mapper;
            _cvService = cvService;
        }

        [HttpGet("/UserCVsExt")]
        public async Task<IActionResult> GetUserCVs(Guid userId, int page, int pageSize)
        {
            return Ok(await _cvService.GetUserCVsAsync(userId, pageSize, page));
        }

        [HttpPost("/CV/{id}/AddSkillKnowledge")]
        public async Task<IActionResult> AddSkillKnowledgeToCV(SkillKnowledgeRequestModel model, Guid id)
        {
            var mappedModel = _mapper.Map<SkillKnowledgeRequestModel, SkillKnowledgeServiceModel>(model);

            try
            {
                await _cvService.AddSkillKnowledgeToCVAsync(mappedModel, id);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("/CV/{CVId}/DeleteSkillKnowledge/{SkillKnowledgeId}")]
        public async Task<IActionResult> DeleteSkillKnowledgeFromCV(Guid SkillKnowledgeId, Guid CVId)
        {
            try
            {
                await _cvService.DeleteSkillKnowledgeFromCVAsync(SkillKnowledgeId);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("/CV/{id}/AddJobExperience")]
        public async Task<IActionResult> AddJobExperienceToCV(JobExperienceRequestModel model, Guid id)
        {
            var mappedModel = _mapper.Map<JobExperienceRequestModel, JobExperienceServiceModel>(model);

            try
            {
                await _cvService.AddJobExperienceToCVAsync(mappedModel, id);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("/CV/{CVId}/DeleteJobExperience/{JobExperienceId}")]
        public async Task<IActionResult> DeleteJobExperienceFromCV(Guid JobExperienceId, Guid CVId)
        {
            try
            {
                await _cvService.DeleteJobExperienceFromCVAsync(JobExperienceId);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
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
        public async Task<IActionResult> Update(CVCreationRequestModel cv)
        {
            try
            {
                var mappedCV = _mapper.Map<CVCreationRequestModel, CVCreationServiceModel>(cv);
                await _cvService.UpdateAsync(mappedCV);

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
