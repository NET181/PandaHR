using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>KnowledgeLevelController</c> class.
/// Contains action methods for <c>KnowledgeLevel</c>.
/// <list type="bullet">
/// <item>
/// <term>GetAllAsync</term>
/// <description>Get all knowledge levels</description>
/// </item>
/// <item>
/// <term>GetByIdAsync</term>
/// <description>Get knowledge level by ID</description>
/// </item>
/// <item>
/// <term>Add</term>
/// <description>Create new knowledge level</description>
/// </item>
/// <item>
/// <term>UpdateAsync</term>
/// <description>Update existing knowledge level</description>
/// </item>
/// <item>
/// <term>Remove</term>
/// <description>Remove existing knowledge level</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeLevelController : Controller
    {
        private readonly IKnowledgeLevelService _knowledgeLevelService;

        public KnowledgeLevelController(IKnowledgeLevelService knowledgeLevelService)
        {
            _knowledgeLevelService = knowledgeLevelService;
        }

        // GET: api/KnowledgeLevel
        /// <summary>
        /// Get all knowledge levels.
        /// </summary>
        /// <returns>
        /// The set of all knowledge levels.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var KnowledgeLevels = await _knowledgeLevelService.GetAllAsync();

                if (KnowledgeLevels == null)
                {
                    //_logger.LogError("skills with the id sent from client doesn't exist");
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

        // GET: api/KnowledgeLevel/5 
         /// <summary>
        /// Get knowledge level by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Knowledge level having given ID or NotFound status if no knowledge levels with such ID.
        /// </returns>
        /// <param name="id">ID.</param>   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var knowledgeLevel = await _knowledgeLevelService.GetByIdAsync(id);

                if (knowledgeLevel != null)
                {
                    return StatusCode(200, knowledgeLevel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/KnowledgeLeve/5
        /// <summary>
        /// Update knowledge level by <paramref name="id"/> from <paramref name="knowledgeLevel"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="knowledgeLevel">Request body.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, KnowledgeLevel knowledgeLevel)
        {
            try
            {
                knowledgeLevel.Id = id;
                await _knowledgeLevelService.UpdateAsync(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/KnowledgeLevel
         /// <summary>
        /// Add new knowledge level from <paramref name="knowledgeLevel"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="knowledgeLevel">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> Add(KnowledgeLevel knowledgeLevel)
        {
            try
            {
                await _knowledgeLevelService.AddAsync(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/KnowledgeLevel/5
        /// <summary>
        /// Remove knowledge level from <paramref name="knowledgeLevel"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="knowledgeLevel">Request body.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(KnowledgeLevel knowledgeLevel)
        {
            try
            {
                await _knowledgeLevelService.RemoveAsync(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

