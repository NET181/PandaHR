using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.Skill;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Models.SkillKnowledge;
using PandaHR.Api.Models.JobExperience;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Models.JobExperience;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private IMapper _mapper;
        private readonly ICVService _cvService;
        private readonly ISkillService _skillService;
        private readonly IWebHostEnvironment _env;

        public CVController(IMapper mapper, ICVService cvService, ISkillService skillService, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _cvService = cvService;
            _skillService = skillService;
            _env = env;
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

        [HttpGet("{id}/export/{type}")]
        public async Task<IActionResult> ExportCv(Guid id, string type = "docx")
        {
            try
            {
                var file = await _cvService.ExportCVAsync(id, _env.WebRootPath, type);

                return File(file.FileContents, file.ContentType, file.FileName);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("/UserCVExt/{userId}")]
        public async Task<IActionResult> GetUserCV(Guid userId)
        {
            return Ok(await _cvService.GetUserCVAsync(userId));
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

        // GET: api/UserCVsSummary/5
        [HttpGet("/UserCVSummary/{userId}")]
        public async Task<IActionResult> GetUserCVSummary(Guid userId)
        {
            var item = await _cvService.GetUserCVPreviewAsync(userId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet("/CVSummary", Name = "GetCVSummary")]
        public async Task<IActionResult> GetCVSummary(Guid id)
        {
            return Ok(await _cvService.GetByIdAsync(id));
        }

        [HttpGet("/CreatedCV", Name = "CreatedCV")]
        public IActionResult CreatedCV(CVServiceModel cv)
        {
            return Ok(_cvService.GetByIdAsync(cv.Id));
        }

        // GET: api/VacanciesForCV/5
        [HttpGet("/VacanciesForCV/{CVId}")]
        public async Task<IActionResult> GetVacanciesForCV(Guid CVId, int page = 1, int pageSize = 10)
        {
            var item = await _cvService.GetVacanciesForCV(CVId, page, pageSize);

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
            var createdCV = await _cvService.AddAsync(cvServiceModel);

            CreatedResult result = new CreatedResult("CreatedCV", createdCV);
            return result;
            //return CreatedAtRoute("GetCVSummary", new { id = createdCV.Id }, createdCV);
        }
    }
}
