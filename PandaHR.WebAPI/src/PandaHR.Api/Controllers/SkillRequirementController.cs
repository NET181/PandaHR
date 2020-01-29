using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillRequirementController : ControllerBase
    {
        private readonly ISkillRequirementService _skillRequirementService;

        public SkillRequirementController(ISkillRequirementService skillRequirementService)
        {
            _skillRequirementService = skillRequirementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _skillRequirementService.GetAllAsync();

            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SkillRequirement skillRequirement)
        {
            await _skillRequirementService.AddAsync(skillRequirement);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, SkillRequirement skillRequirement)
        {
            await _skillRequirementService.UpdateAsync(skillRequirement);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _skillRequirementService.RemoveAsync(id);

            return Ok();
        }
    }
}
