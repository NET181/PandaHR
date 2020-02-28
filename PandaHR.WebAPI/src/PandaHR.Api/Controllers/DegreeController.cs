using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Degree;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Degree;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Controllers
{
    /// <summary>
/// The <c>DegreeController</c> class.
/// Contains action methods for <c>Degree</c>.
/// <list type="bullet">
/// <item>
/// <term>GetDegreesAsync</term>
/// <description>Get all degrees</description>
/// </item>
/// <item>
/// <term>Get</term>
/// <description>Get degree by ID</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create new degree</description>
/// </item>
/// <item>
/// <term>Put</term>
/// <description>Update existing degree</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing degree</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;
        private readonly IMapper _mapper;

        public DegreeController(IDegreeService degreeService, IMapper mapper)
        {
            _degreeService = degreeService;
            _mapper = mapper;
        }

        // GET: api/degree
        /// <summary>
        /// Get all degrees.
        /// </summary>
        /// <returns>
        /// The set of all degrees.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetDegreesAsync()
        {
            var degreesServiceModel = await _degreeService.GetDegreesAsync();

            var responseModels = _mapper
                .Map<ICollection<DegreeServiceModel>
                , ICollection<DegreeResponseModel>>(degreesServiceModel);

            if (responseModels != null)
            {
                return Ok(responseModels);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Degree/5 
        /// <summary>
        /// Get degree by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Degree having given ID or NotFound status if no degrees with such ID.
        /// </returns>
        /// <param name="id">ID.</param>   
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
        /// <summary>
        /// Create new degree from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="value">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Degree value)
        {
            await _degreeService.AddAsync(value);

            return Ok();
        }

        // PUT: api/Degree/5
        /// <summary>
        /// Update degree by <paramref name="id"/> from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="value">Request body.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Degree value)
        {
            value.Id = id;
            await _degreeService.UpdateAsync(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Remove degree by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _degreeService.RemoveAsync(id);

            return Ok();
        }
    }
}