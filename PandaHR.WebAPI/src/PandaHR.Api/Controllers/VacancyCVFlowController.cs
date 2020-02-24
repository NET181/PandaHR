using System;
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

        [HttpGet("/Status", Name = "GetFlowStatus")]
        public IActionResult GetFlowStatus(Guid CVId, Guid vacancyId)
        {
            var status = _vacancyCVFlowService.GetFlowStatusAsync(CVId, vacancyId);

            if (status != null)
            {
                return Ok(status);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/VacancyCVFlow
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]VacancyCVFlowCreationRequestModel vacancyCVFlow)
        {
            if (vacancyCVFlow == null)
            {
                return BadRequest();
            }

            var flow = _mapper.Map<VacancyCVFlowCreationRequestModel, VacancyCVFlowCreationServiceModel>(vacancyCVFlow);
            var addedFlow = await _vacancyCVFlowService.AddAsync(flow);

            return CreatedAtRoute("GetVacancyCVFlow", new { id = addedFlow.Id }, addedFlow);
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

        [HttpPatch]
        public async Task<IActionResult> PatchAsync([FromBody]VacancyCVFlowEditStatusRequestModel vacancyCVFlow)
        {
            if (vacancyCVFlow == null)
            {
                return BadRequest();
            }

            var flow = _mapper.Map<VacancyCVFlowEditStatusRequestModel, VacancyCVFlowEditStatusServiceModel>(vacancyCVFlow);
            await _vacancyCVFlowService.ChangeStatus(flow);

            return Ok();
        }
    }
}
