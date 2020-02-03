using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.Degree;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Degree;
using PandaHR.Api.DAL.Models.Entities;
using System;

namespace PandaHR.Api.Controllers
{
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

        // GET: api/degrees
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

        // GET: api/Degree
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allDegrees = await _degreeService.GetAllAsync();

            return Ok(allDegrees);
        }

        // GET: api/Degree/5    
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
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Degree value)
        {
            await _degreeService.AddAsync(value);

            return Ok();
        }

        // PUT: api/Degree/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]Degree value)
        {
            value.Id = id;
            await _degreeService.UpdateAsync(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _degreeService.RemoveAsync(id);

            return Ok();
        }
    }
}
