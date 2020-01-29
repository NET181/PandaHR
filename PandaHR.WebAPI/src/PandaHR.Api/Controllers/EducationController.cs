using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        // GET: api/Education
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var educations = await _educationService.GetAllAsync();

            return Ok(educations);
        }

        // GET: api/Education/5    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var education = await _educationService.GetByIdAsync(id);

            if (education != null)
            {
                return Ok(education);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Education
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Education value)
        {
            await _educationService.AddAsync(value);

            return Ok();
        }

        // PUT: api/Education/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Education value)
        {
            value.Id = id;
            await _educationService.UpdateAsync(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _educationService.RemoveAsync(id);

            return Ok();
        }
    }
}
