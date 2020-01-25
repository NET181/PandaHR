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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        // GET: api/Country
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_countryService.GetAllAsync());
        }

        // GET: api/Country/5
        [HttpGet("{id}"/*, Name = "Get"*/)]
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
        public void Post(Country value)
        {
            
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
