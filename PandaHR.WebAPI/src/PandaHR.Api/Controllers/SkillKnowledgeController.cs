using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    public class SkillKnowledgeController : Controller
    {
        private readonly ISkillKnowledgeServise _skillKnowledgeService;

        public SkillKnowledgeController(ISkillKnowledgeServise skillService)
        {
            _skillKnowledgeService = skillService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var skillKnowledges = await _skillKnowledgeService.GetAllAsync();

                if (skillKnowledges == null)
                {
                    return BadRequest("Owner object is null");
                }

                return Ok(skillKnowledges);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var skillKnowledge = await _skillKnowledgeService.GetById(id);

                if (skillKnowledge == null)
                {
                    return BadRequest("Owner object is null");
                }

                return Ok(skillKnowledge);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SkillKnowledge skillKnowledge)
        {
            await _skillKnowledgeService.Add(skillKnowledge);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]SkillKnowledge skillKnowledge)
        {
            var item = await _skillKnowledgeService.GetById(id);

            if (item == null)
            {
                return BadRequest("Owner object is null");
            }

            skillKnowledge.Id = id;
            await _skillKnowledgeService.Update(skillKnowledge);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var skillKnowledge = await _skillKnowledgeService.GetById(id);

            if (skillKnowledge == null)
            {
                return BadRequest("Owner object is null");
            }

            await _skillKnowledgeService.Remove(skillKnowledge);

            return Ok();
        }
    }
}
