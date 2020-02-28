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
/// <summary>
/// The <c>CityController</c> class.
/// Contains action methods for <c>City</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get all cities</description>
/// </item>
/// <item>
/// <term>Get</term>
/// <description>Get city by ID</description>
/// </item>
/// <item>
/// <term>GetCitiesByTermToSearchAsync</term>
/// <description>Get city by term using autofill</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create new city</description>
/// </item>
/// <item>
/// <term>Put</term>
/// <description>Update existing city</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing city</description>
/// </item>
/// </list>
/// </summary>
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
        /// <summary>
        /// Get all cities.
        /// </summary>
        /// <returns>
        /// The set of all cities.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.GetAllAsync());
        }

        // GET: api/Country/5
         /// <summary>
        /// Get city by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// City by ID or NotFound status if no cities with such ID.
        /// </returns>
        /// <param name="id">ID.</param>
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

         /// <summary>
        /// Get cities by string <paramref name="term"/> using autofill.
        /// </summary>
        /// <returns>
        /// Cities set with names due to term using autofill or NotFound status cities set is null.
        /// </returns>
        /// <param name="term">String for autofill.</param>
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
        /// <summary>
        /// Create new city from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="value">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]City value)
        {
            await _cityService.AddAsync(value);
            return Ok();
        }

        // PUT: api/Country/5
        /// <summary>
        /// Update city by <paramref name="id"/> from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="value">Request body.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]City value)
        {
            value.Id = id;
            await _cityService.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Remove city by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cityService.RemoveAsync(id);
            return Ok();
        }
    }
}
