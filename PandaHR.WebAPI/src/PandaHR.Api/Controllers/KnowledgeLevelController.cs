using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

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
            catch 
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/KnowledgeLevel/5    
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
