using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Experience;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Experience;

namespace PandaHR.Api.Controllers
{
 /// <summary>
/// The <c>ExperienceController</c> class.
/// Contains action methods for <c>Experience</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get all experiences</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;

        public ExperienceController(IExperienceService experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }


        // GET: api/Experience
         /// <summary>
        /// Get all experinces.
        /// </summary>
        /// <returns>
        /// The set of all experiences.
        /// </returns>
        [HttpGet]
        public async Task<IEnumerable<ExperienceResponseModel>> Get()
        {
            var serviceModels = await _experienceService.GetAllAsync();
            return _mapper
                .Map<IEnumerable<ExperienceServiceModel>, IEnumerable<ExperienceResponseModel>>(serviceModels);
        }
    }
}