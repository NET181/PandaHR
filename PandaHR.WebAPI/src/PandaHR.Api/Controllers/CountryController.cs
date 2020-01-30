using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Country country = await _countryService.GetByIdAsync(id);
            if (country != null)
            {
                return Ok(country);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Country
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Country value)
        {
            await _countryService.AddAsync(value);
            return Ok();
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Country value)
        {
            value.Id = id;
            await _countryService.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _countryService.RemoveAsync(id);
            return Ok();
        }
    }
}
