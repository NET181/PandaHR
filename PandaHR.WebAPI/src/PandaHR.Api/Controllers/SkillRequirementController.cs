using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>SkillRequirementController</c> class.
/// Contains action methods for <c>SkillRequirement</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get all skill requirements</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create new skill requirement</description>
/// </item>
/// <item>
/// <term>Put</term>
/// <description>Update existing skill requirement</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing skill requirement</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillRequirementController : ControllerBase
    {
        private readonly ISkillRequirementService _skillRequirementService;

        public SkillRequirementController(ISkillRequirementService skillRequirementService)
        {
            _skillRequirementService = skillRequirementService;
        }

        /// <summary>
        /// Get all skill requirements.
        /// </summary>
        /// <returns>
        /// The set of all skill requirements.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _skillRequirementService.GetAllAsync();

            return Ok(skills);
        }

        /// <summary>
        /// Create new skill requirement from <paramref name="skillRequirement"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="skillRequirement">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> Post(SkillRequirement skillRequirement)
        {
            await _skillRequirementService.AddAsync(skillRequirement);

            return Ok();
        }

        /// <summary>
        /// Update skill requirement by <paramref name="id"/> from <paramref name="skillRequirement"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="skillRequirement">Request body.</param>
        [HttpPut]
        public async Task<IActionResult> Put(Guid id, SkillRequirement skillRequirement)
        {
            await _skillRequirementService.UpdateAsync(skillRequirement);

            return Ok();
        }

         /// <summary>
        /// Remove city by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _skillRequirementService.RemoveAsync(id);

            return Ok();
        }
    }
}
