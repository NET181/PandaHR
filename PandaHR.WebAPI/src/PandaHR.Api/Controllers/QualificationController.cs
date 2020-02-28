using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Qualification;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Qualification;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>QualificationController</c> class.
/// Contains action methods for <c>Quilification</c>.
/// <list type="bullet">
/// <item>
/// <term>GetAllQualifications</term>
/// <description>Get all qualifications</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create new qualification</description>
/// </item>
/// <item>
/// <term>Put</term>
/// <description>Update existing qualification</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing qualification</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;
        private readonly IMapper _mapper;

        public QualificationController(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }

        // GET: api/Qualification
         /// <summary>
        /// Get all qualifications.
        /// </summary>
        /// <returns>
        /// The set of all qualifications.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllQualifications()
        {
            var serviceModel = await _qualificationService.GetAllQualificationsAsync();

            var requestModel = _mapper.Map<IEnumerable<QualificationServiceModel>
                , IEnumerable<QualificationResponseModel>>(serviceModel);

            return Ok(requestModel);
        }

        //POST: api/Qualification
        /// <summary>
        /// Create new qualification from <paramref name="qualification"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="qualification">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> Post(Qualification qualification)
        {
            if(qualification == null)
            {
                return BadRequest();
            }

            await _qualificationService.AddAsync(qualification);

            return Ok();
        }

        /// <summary>
        /// Update qualification by <paramref name="id"/> from <paramref name="qualification"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="qualification">Request body.</param>
        [HttpPut]
        public async Task<IActionResult> Put(Guid id, Qualification qualification)
        {
            await _qualificationService.UpdateAsync(qualification);

            return Ok();
        }

        /// <summary>
        /// Remove qualification by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">GUID.</param>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _qualificationService.RemoveAsync(id);

            return Ok();
        }
    }
}

