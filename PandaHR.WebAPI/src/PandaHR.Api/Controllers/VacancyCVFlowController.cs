using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.VacancyCVFlow;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.VacancyCVFlow;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyCVFlowController : ControllerBase
    {
        private readonly IVacancyCVFlowService _vacancyCVFlowService;
        private readonly IMapper _mapper;

        public VacancyCVFlowController(IVacancyCVFlowService vacancyCVFlowService,
            IMapper mapper)
        {
            _vacancyCVFlowService = vacancyCVFlowService;
            _mapper = mapper;
        }

        // GET: api/VacancyCVFlow
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vacancyCVFlows = await _vacancyCVFlowService.GetAllAsync();

            return Ok(vacancyCVFlows);
        }

        // GET: api/VacancyCVFlow/GetAllFlowsByVacancyId/5
        [HttpGet("GetAllFlowsByVacancyId/{vacancyId}")]
        public async Task<IActionResult> GetAllFlowsByVacancyId(Guid vacancyId)
        {
            var flowSeviceModel = await _vacancyCVFlowService.GetAllFlowsByVacancyIdAsync(vacancyId);

            var flowResponceModel = _mapper.Map<IEnumerable<VacancyCVFlowServiceModel>,
                    IEnumerable<VacancyCVFlowResponceModel>>(flowSeviceModel);

            return Ok(flowResponceModel);
        }

        // GET: api/VacancyCVFlow/5    
        [HttpGet("{id}", Name = "GetVacancyCVFlow")]
        public async Task<IActionResult> Get(Guid id)
        {
            var vacancyCVFlow = await _vacancyCVFlowService.GetByIdAsync(id);

            if (vacancyCVFlow != null)
            {
                return Ok(vacancyCVFlow);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/VacancyCVFlow
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]VacancyCVFlow value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            await _vacancyCVFlowService.AddAsync(value);

            return CreatedAtRoute("GetVacancyCVFlows", new { id = value.Id }, value);
        }

        // PUT: api/VacancyCVFlow/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]VacancyCVFlow value)
        {
            var item = _vacancyCVFlowService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            if (value == null)
            {
                return BadRequest();
            }

            value.Id = id;
            await _vacancyCVFlowService.UpdateAsync(value);

            return Ok();
        }

        // DELETE: api/VacancyCVFlow/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = _vacancyCVFlowService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _vacancyCVFlowService.RemoveAsync(id);

            return NoContent();
        }


    }
}
