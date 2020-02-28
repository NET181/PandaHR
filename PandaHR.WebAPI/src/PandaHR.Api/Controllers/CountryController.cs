using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
           /// <summary>
/// The <c>CountryController</c> class.
/// Contains action methods for <c>Country</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get all countries</description>
/// </item>
/// <item>
/// <term>Get</term>
/// <description>Get country by ID</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create new country</description>
/// </item>
/// <item>
/// <term>Put</term>
/// <description>Update existing country</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing country</description>
/// </item>
/// </list>
/// </summary>
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
        /// <summary>
        /// Get all countries.
        /// </summary>
        /// <returns>
        /// The set of all countries.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        // GET: api/Country/5
        /// <summary>
        /// Get country by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Coumtry having given ID or NotFound status if no countries with such ID.
        /// </returns>
        /// <param name="id">GUID.</param>
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
        /// <summary>
        /// Create new country from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="value">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Country value)
        {
            await _countryService.AddAsync(value);
            return Ok();
        }

        /// PUT: api/Country/5
        /// <summary>
        /// Update country by <paramref name="id"/> from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">GUID.</param>
        /// <param name="value">Request body.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Country value)
        {
            value.Id = id;
            await _countryService.UpdateAsync(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Remove country by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _countryService.RemoveAsync(id);
            return Ok();
        }
    }
}
