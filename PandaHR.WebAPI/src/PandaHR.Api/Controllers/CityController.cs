using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.GetAllAsync());
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            City city = _cityService.GetById(id).Result;
            if (city != null)
            {
                return Ok(city);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Country
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]City value)
        {
            await _cityService.Add(value);
            return Ok();
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]City value)
        {
            value.Id = id;
            if (await _cityService.Update(value))
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
            if (await _cityService.Remove(id))
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
