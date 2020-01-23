using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var skills = await _skillService.GetAllAsync();

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
