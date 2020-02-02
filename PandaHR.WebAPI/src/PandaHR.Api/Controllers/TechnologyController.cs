using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Technology;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Technology;


namespace PandaHR.Api.Controllers
{
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
        [HttpGet("names")]
        public async Task<IActionResult> GetTechnologyNames()
        {
            var technologyNamesServiceModel = await _technologyService.GetTechnologyNamesAsync();
            var responceModels = _mapper
                .Map<ICollection<TechnologyNameServiceModel>
                , ICollection<TechnologyNameResponceModel>>(technologyNamesServiceModel);

            if(responceModels != null)
            {
                return Ok(responceModels);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
