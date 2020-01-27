using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var skills = await _skillService.GetAllAsync();

                if (skills == null)
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
                return Ok(skills);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var skill = await _skillService.GetById(id);

                if (skill == null)
                {
                    return BadRequest("Owner object is null");
                }

                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Skill skill)
        {
            await _skillService.Add(skill);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Skill skill)
        {
            var item = await _skillService.GetById(id);

            if(item == null)
            {
                return BadRequest("Owner object is null");
            }

            skill.Id = id;
            await _skillService.Update(skill); 

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var skill = await _skillService.GetById(id);

            if(skill == null)
            {
                return BadRequest("Owner object is null");
            }

            await _skillService.Remove(skill);

            return Ok();
        }
    }
}
