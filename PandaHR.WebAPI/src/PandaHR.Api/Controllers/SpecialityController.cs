using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        // GET: api/Speciality
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var specialities = await _specialityService.GetAllAsync();

            return Ok(specialities);
        }

        // GET: api/Speciality/5    
        [HttpGet("{id}", Name = "GetSpeciality")]
        public async Task<IActionResult> Get(Guid id)
        {
            var speciality = await _specialityService.GetByIdAsync(id);

            if (speciality != null)
            {
                return Ok(speciality);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Speciality
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Speciality value)
        {
            if(value == null)
            {
                return BadRequest();
            }

            await _specialityService.AddAsync(value);

            return CreatedAtRoute("GetSpeciality", new { id = value.Id }, value);
        }

        // PUT: api/Speciality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Speciality value)
        {
            var item = _specialityService.GetByIdAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            if(value == null)
            {
                return BadRequest();
            }

            value.Id = id;
            await _specialityService.UpdateAsync(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = _specialityService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _specialityService.RemoveAsync(id);

            return NoContent();
        }
    }
}
