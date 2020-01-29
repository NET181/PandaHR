using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;

        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _qualificationService.GetAllAsync();

            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Qualification qualification)
        {
            await _qualificationService.AddAsync(qualification);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, Qualification qualification)
        {
            await _qualificationService.UpdateAsync(qualification);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _qualificationService.RemoveAsync(id);

            return Ok();
        }
    }
}
