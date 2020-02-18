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

        // GET: api/UserCVsExt/5
        [HttpGet("/UserCVsExt/{userId}")]
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
        public async Task<IActionResult> GetCVsPaged(Guid userId, int pageSize, int page)
        {
            var item = await _cvService.GetUserCVsAsync(userId, pageSize, page);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // GET: api/UserCVsSummary/5
        [HttpGet("/UserCVsSummary/{userId}")]
        public async Task<IActionResult> GetUserCVsSummary(Guid userId, int page, int pageSize)
        {
            var item = await _cvService.GetUserCVsPreviewAsync(userId, pageSize, page);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // GET: api/VacanciesForCV/5
        [HttpGet("/VacanciesForCV/{CVId}")]
        public async Task<IActionResult> GetVacanciesForCV(Guid CVId, int page, int pageSize)
        {
            var item = await _cvService.GetVacanciesForCV(CVId, pageSize, page);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // DELETE: api/CV/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _cvService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _cvService.RemoveAsync(id);

            return Ok();
        }

        // PUT: api/CV
        [HttpPut]
        public async Task<IActionResult> Put(CVCreationRequestModel cv)
        {
            if (cv == null)
            {
                return BadRequest();
            }

            var cvServiceModel = _mapper.Map<CVCreationRequestModel, CVCreationServiceModel>(cv);
            await _cvService.UpdateAsync(cvServiceModel);

            return Ok();
        }

        // POST: api/CV
        [HttpPost]
        public async Task<IActionResult> Post(CVCreationRequestModel cv)
        {
            if (cv == null)
            {
                BadRequest();
            }

            var cvServiceModel = _mapper.Map<CVCreationRequestModel, CVCreationServiceModel>(cv);
            await _cvService.AddAsync(cvServiceModel);

            return Ok();
        }
    }
}
