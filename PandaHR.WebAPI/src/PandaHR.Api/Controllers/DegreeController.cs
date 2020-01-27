using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;

        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        // GET: api/Degree
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var degrees = await _degreeService.GetAllAsync();

            return Ok(degrees);
        }

        // GET: api/Degree/5    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var degree = await _degreeService.GetByIdAsync(id);

            if (degree != null)
            {
                return Ok(degree);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Degree
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Degree value)
        {
            await _degreeService.AddAsync(value);
            return Ok();
        }

        // PUT: api/Degree/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Degree value)
        {
            value.Id = id;
            await _degreeService.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _degreeService.RemoveAsync(id);
            return Ok();
        }
    }
}
