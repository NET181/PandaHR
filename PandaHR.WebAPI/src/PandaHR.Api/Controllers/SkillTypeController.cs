using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
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
