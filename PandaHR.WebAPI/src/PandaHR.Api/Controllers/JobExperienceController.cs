using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobExperienceController : ControllerBase
    {
        private readonly IJobExperienceService _jobExperienceService;
        public JobExperienceController(IJobExperienceService jobExperienceService)
        {
            _jobExperienceService = jobExperienceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var jobExperience = await _jobExperienceService.GetByIdAsync(id);

            if(jobExperience != null)
            {
                return Ok(jobExperience);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                await _jobExperienceService.RemoveAsync(id);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(JobExperience jobExperience)
        {
            try
            {
                await _jobExperienceService.UpdateAsync(jobExperience);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobExperience jobExperience)
        {
            try
            {
                await _jobExperienceService.AddAsync(jobExperience);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}