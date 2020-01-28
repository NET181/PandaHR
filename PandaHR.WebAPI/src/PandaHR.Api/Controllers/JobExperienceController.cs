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

        [HttpGet]
        public async Task<JobExperience> Get(Guid jobExperienceId)
        {
            var jobExperience = await _jobExperienceService.GetByIdAsync(jobExperienceId);

            return jobExperience;
        }

        [HttpDelete]
        public void Remove(JobExperience jobExperience)
        {
            _jobExperienceService.RemoveAsync(jobExperience);
        }

        [HttpPut]
        public void Update(JobExperience jobExperience)
        {
            _jobExperienceService.UpdateAsync(jobExperience);
        }

        [HttpPost]
        public void Add(JobExperience jobExperience)
        {
            _jobExperienceService.AddAsync(jobExperience);
        }
    }
}