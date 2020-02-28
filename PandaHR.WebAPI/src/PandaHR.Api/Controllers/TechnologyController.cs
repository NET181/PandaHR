using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Technology;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Technology;


namespace PandaHR.Api.Controllers
{
    /// <summary>
/// The <c>TechnologyController</c> class.
/// Contains action methods for <c>Technology</c>.
/// <list type="bullet">
/// <item>
/// <term>GetTechnologyNames</term>
/// <description>Get all technology names</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;
        private readonly IMapper _mapper;

        public TechnologyController(ITechnologyService technologyService, IMapper mapper)
        {
            _technologyService = technologyService;
            _mapper = mapper;
        }

        //GET: api/techologies/names
        /// <summary>
        /// Get all technology names.
        /// </summary>
        /// <returns>
        /// The set of all technology names or NotFound status if there is no technology names.
        /// </returns>
        [HttpGet("names")]
        public async Task<IActionResult> GetTechnologyNames()
        {
            var technologyNamesServiceModel = await _technologyService.GetTechnologyNamesAsync();

            var responseModels = _mapper
                .Map<ICollection<TechnologyNameServiceModel>
                , ICollection<TechnologyNameResponseModel>>(technologyNamesServiceModel);

            if(responseModels != null)
            {
                return Ok(responseModels);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
