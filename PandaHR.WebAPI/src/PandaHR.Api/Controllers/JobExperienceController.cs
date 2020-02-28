using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>JobExperienceController</c> class.
/// Contains action methods for <c>JobExperience</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get job experience by ID</description>
/// </item>
/// <item>
/// <term>Add</term>
/// <description>Add new job experience</description>
/// </item>
/// <item>
/// <term>Update</term>
/// <description>Update existing job experience</description>
/// </item>
/// <item>
/// <term>Remove</term>
/// <description>Remove existing job experience</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobExperienceController : ControllerBase
    {
        private readonly IJobExperienceService _jobExperienceService;
        public JobExperienceController(IJobExperienceService jobExperienceService)
        {
            _jobExperienceService = jobExperienceService;
        }

         /// <summary>
        /// Get job experience by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Job experience having given ID or NotFound status if no experiences with such ID.
        /// </returns>
        /// <param name="id">ID.</param>
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

        /// <summary>
        /// Remove experience by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
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

         /// <summary>
        /// Update experience from <paramref name="jobExperience"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="jobExperience">Request body.</param>
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

        /// <summary>
        /// Create new job experience from <paramref name="jobExperience"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="jobExperience">Request body.</param>
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