﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Skill;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _skillService.GetAllAsync();

            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
        }

        // GET: api/skills/names
        [HttpGet("names")]
        public async Task<IActionResult> GetSkillNames()
        {
            var skillNamesServiceModels = await _skillService.GetSkillNames();
            var responseModels = _mapper
                .Map<ICollection<SkillNameServiceModel>, ICollection<SkillNameResponseModel>>(skillNamesServiceModels);
            if (responseModels != null)
            {
                return Ok(responseModels);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var skill = await _skillService.GetByIdAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Skill skill)
        {
            await _skillService.AddAsync(skill);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Skill skill)
        {
            var item = await _skillService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            skill.Id = id;
            await _skillService.UpdateAsync(skill);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var skill = await _skillService.GetByIdAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            await _skillService.RemoveAsync(skill);

            return Ok();
        }
    }
}
