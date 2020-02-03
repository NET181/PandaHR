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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateAsync(Company company)
        {
            //if (ModelState.IsValid)
            //{
            await _companyService.AddAsync(company);

            return Ok(company);
            //}
            //else
            //{
            //    return ValidationProblem();
            //}
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _companyService.GetAllAsync();
        }

        [HttpPut]
        public async Task<ActionResult<Company>> UpdateAsync(Company company)
        {
            if (company == null)
            {
                return BadRequest("owner object is null");
            }

            bool doesExist = _companyService.GetByIdAsync(company.Id).Result != null;

            if (!doesExist)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            await _companyService.UpdateAsync(company);

            return Ok(company);
            //}
            //else
            //{
            //    return ValidationProblem();
            //}
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteAsync(Guid id)
        {
            await _companyService.RemoveAsync(id);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetByIdAsync(Guid id)
        {
            Company givenCompany = await _companyService.GetByIdAsync(id);

            if (givenCompany == null)
            {
                return NotFound(id);
            }

            return new ObjectResult(givenCompany);
        }

        #region uncompleted code
        [HttpDelete("Users")] //[HttpDelete("Users/{companyId}/{userId}")]
        public async Task<ActionResult<UserCompany>> RemoveUserFromCompanyAsync(UserCompany userCompany)
        {
            await _companyService.RemoveUserFromCompanyAsync(userCompany);

            return Ok(userCompany);
        }

        [HttpDelete("Cities")]
        public async Task<ActionResult<CompanyCity>> RemoveCompanyFromCitiesAsync(CompanyCity companyCity)
        {
            await _companyService.RemoveCompanyFromCityAsync(companyCity);

            return Ok(companyCity);
        }

        [HttpPost("Users")]
        public async Task<ActionResult<UserCompany>> AddUserToCompanyAsync(UserCompany userCompany)
        {
            await _companyService.AddUserToCompanyAsync(userCompany);

            return Ok(userCompany);
        }

        [HttpPost("Cities")]
        public async Task<ActionResult<CompanyCity>> AddCompanyToCityAsync(CompanyCity companyCity)
        {
            await _companyService.AddCompanyToCityAsync(companyCity);

            return Ok(companyCity);
        }
        #endregion
    }
}