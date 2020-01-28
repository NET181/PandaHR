using Microsoft.AspNetCore.Mvc;
using System;
using PandaHR.Api.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Controllers
{
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(object id)
        {
            try
            {
                var knowledgeLevel = await _knowledgeLevelService.GetById(id);

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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(object id, KnowledgeLevel knowledgeLevel)
        {
            try
            {
                knowledgeLevel.Id = (Guid)id;
                await _knowledgeLevelService.Update(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/KnowledgeLevel
        [HttpPost]
        public async Task<IActionResult> Add(KnowledgeLevel knowledgeLevel)
        {
            try
            {
                await _knowledgeLevelService.Add(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/KnowledgeLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(KnowledgeLevel knowledgeLevel)
        {
            try
            {
                await _knowledgeLevelService.Remove(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
