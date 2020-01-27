using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Get(Guid id)
        {
            Country country = _countryService.GetById(id).Result;
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
            await _countryService.Add(value);
            return Ok();
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Country value)
        {
            value.Id = id;
            if (await _countryService.Update(value))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _countryService.Remove(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
