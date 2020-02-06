using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.City;
using PandaHR.Api.Services.Models.City;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.GetAllAsync());
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            City city = await _cityService.GetByIdAsync(id);
            if (city != null)
            {
                return Ok(city);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("autofill/{term}")]
        public async Task<IActionResult> GetSkillsByTermToSearchAsync(string term)
        {
            var cityNamesServiceModels = await _cityService.GetCityNamesByTerm(term);
            var responseModels = _mapper
                .Map<ICollection<CityNameServiceModel>, ICollection<CityNameResponseModel>>(cityNamesServiceModels);

            if (responseModels != null)
            {
                return Ok(responseModels);
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
            await _cityService.AddAsync(value);
            return Ok();
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]City value)
        {
            value.Id = id;
            await _cityService.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cityService.RemoveAsync(id);
            return Ok();
        }
    }
}
