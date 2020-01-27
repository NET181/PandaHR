using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillTypeController : Controller
    {
        private readonly ISkillTypeService _skillTypeService;

        public SkillTypeController(ISkillTypeService skillTypeService)
        {
            _skillTypeService = skillTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var KnowledgeLevels = await _skillTypeService.GetAllAsync();

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
              var skillType = await _skillTypeService.GetById(id);

                return StatusCode(200, skillType);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> Update(SkillType skillType)
        {
            try
            {
                await _skillTypeService.Update(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> Add(SkillType skillType)
        {
            try
            {
                await _skillTypeService.Add(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> Remove(SkillType skillType)
        {
            try
            {
                await _skillTypeService.Remove(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
