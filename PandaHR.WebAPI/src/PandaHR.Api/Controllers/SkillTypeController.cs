using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{/// <summary>
/// The <c>SkillTypeController</c> class.
/// Contains action methods for <c>SkillType</c>.
/// <list type="bullet">
/// <item>
/// <term>GetAllAsync</term>
/// <description>Get all skill types</description>
/// </item>
/// <item>
/// <term>GetByIdAsync</term>
/// <description>Get skill type by ID</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create new skill type</description>
/// </item>
/// <item>
/// <term>UpdateAsync</term>
/// <description>Update existing skill type</description>
/// </item>
/// <item>
/// <term>RemoveAsync</term>
/// <description>Remove existing skill type</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillTypeController : Controller
    {
        private readonly ISkillTypeService _skillTypeService;

        public SkillTypeController(ISkillTypeService skillTypeService)
        {
            _skillTypeService = skillTypeService;
        }

        // GET: api/SkillType
        /// <summary>
        /// Get all skill types.
        /// </summary>
        /// <returns>
        /// The set of all skill types.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var KnowledgeLevels = await _skillTypeService.GetAllAsync();

                if (KnowledgeLevels == null)
                {

                    return BadRequest("Owner object is null");
                }

                return Ok(KnowledgeLevels);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/SkillType/5
        /// <summary>
        /// Get skill type by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Skill type by ID or NotFound status if no skill types with such ID.
        /// </returns>
        /// <param name="id">ID.</param>    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var skillType = await _skillTypeService.GetByIdAsync(id);

                if (skillType != null)
                {
                    return StatusCode(200, skillType);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                //todo log ex
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/SkillType/5
        /// <summary>
        /// Update skill type from <paramref name="skillType"/>.
        /// </summary>
        /// <returns>
        /// Ok status.
        /// </returns>
        /// <param name="skillType">Request body.</param>
        /// <param name="id">ID.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, SkillType skillType)
        {
            try
            {
                skillType.Id = id;
                await _skillTypeService.UpdateAsync(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/SkillType
         /// <summary>
        /// Create new company from <paramref name="skillType"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="skillType">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> AddAsync(SkillType skillType)
        {
            try
            {
                await _skillTypeService.AddAsync(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/SkillType/5
        /// <summary>
        /// Remove skill type from <paramref name="skillType"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="skillType">Request body.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(SkillType skillType)
        {
            try
            {
                await _skillTypeService.RemoveAsync(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
