using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        // GET: api/Vacancy
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var skills = await _vacancyService.GetAllAsync();

                if (skills == null)
                {
                    //_logger.LogError("skills with the id sent from client doesn't exist");
                    return BadRequest("Owner object is null");
                }

                /* 
            * if (!ModelState.IsValid)
               {
                     // _logger.LogError("Invalid skills object sent from client.");
                       return BadRequest("Invalid model object");
              }
                   */
                return Ok(skills);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
