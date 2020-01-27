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

        // GET: api/SkillType
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(object id)
        {
            try
            {
                var skillType = await _skillTypeService.GetById(id);

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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(object id, SkillType skillType)
        {
            try
            {
                skillType.Id = (Guid)id;
                await _skillTypeService.Update(skillType);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/SkillType
        [HttpPost]
        public async Task<IActionResult> AddAsync(SkillType skillType)
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

        // DELETE: api/SkillType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(SkillType skillType)
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
