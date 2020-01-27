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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var KnowledgeLevels = await _knowledgeLevelService.GetAllAsync();

                if (KnowledgeLevels == null)
                {
                    //_logger.LogError("skills with the id sent from client doesn't exist");
                    return BadRequest("Owner object is null");
                }

                /* 
            * if (!ModelState.IsValid)
               {
                     // _logger.LogError("Invalid skills object sent from client.");
                       return BadRequest("Invalid model object");
              }
                   */
                return Ok(KnowledgeLevels);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> GetById(object id)
        {
            try
            {
                var knowledgeLevel = await _knowledgeLevelService.GetById(id);

                return StatusCode(200, knowledgeLevel);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> Update(KnowledgeLevel knowledgeLevel)
        {
            try
            {
                await _knowledgeLevelService.Update(knowledgeLevel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

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
