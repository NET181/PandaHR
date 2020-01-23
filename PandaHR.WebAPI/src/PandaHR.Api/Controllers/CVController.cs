using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private readonly ICVService _cVService;

        public CVController(ICVService cVService)
        {
            _cVService = cVService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var skills = await _cVService.GetAllAsync();

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