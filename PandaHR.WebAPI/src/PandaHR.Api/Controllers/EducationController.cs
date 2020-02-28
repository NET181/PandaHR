using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Education;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Education;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>EducationController</c> class.
/// Contains action methods for <c>Education</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get all educations</description>
/// </item>
/// <item>
/// <term>Get</term>
/// <description>Get education by ID</description>
/// </item>
/// <item>
/// <term>GetByName</term>
/// <description>Get education by term using autofill</description>
/// </item>
/// <item>
/// <term>PostAsync</term>
/// <description>Create new education</description>
/// </item>
/// <item>
/// <term>PutAsync</term>
/// <description>Update existing education</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing education</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(IMapper mapper, IEducationService educationService)
        {
            _mapper = mapper;
            _educationService = educationService;
        }

        // GET: api/Education
        /// <summary>
        /// Get all educations.
        /// </summary>
        /// <returns>
        /// The set of all educations.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var educations = await _educationService.GetAllAsync();

            return Ok(educations);
        }

        // GET: api/Education/5    
         /// <summary>
        /// Get education by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Education having given ID or NotFound status if no educations with such ID.
        /// </returns>
        /// <param name="id">ID.</param>
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

        /// <summary>
        /// Get educatios by string <paramref name="name"/> using autofill.
        /// </summary>
        /// <returns>
        /// Educations set with names due to term using autofill or NotFound status educations set is null.
        /// </returns>
        /// <param name="name">A string.</param>
        [HttpGet]
        [Route("autofill/{name}")]
        public async Task<ActionResult<ICollection<EducationBasicInfoResponse>>> GetByName(string name)
        {
            ICollection<EducationBasicInfoServiceModel> educations = await _educationService.GetBasicInfoByAutofillByName(name);

            ICollection<EducationBasicInfoResponse> educationsResponse = _mapper
                .Map<ICollection<EducationBasicInfoServiceModel>,
                    ICollection<EducationBasicInfoResponse>>(educations);

            if(educationsResponse != null)
            {
                return Ok(educationsResponse);

            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Education
        /// <summary>
        /// Create new education <paramref name="value"/> from request body.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="value">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Education value)
        {
            await _educationService.AddAsync(value);

            return Ok();
        }

        // PUT: api/Education/5
        /// <summary>
        /// Update education by <paramref name="id"/> from <paramref name="value"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="value">Request body.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Education value)
        {
            value.Id = id;
            await _educationService.UpdateAsync(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
         /// <summary>
        /// Remove education by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _educationService.RemoveAsync(id);

            return Ok();
        }
    }
}
