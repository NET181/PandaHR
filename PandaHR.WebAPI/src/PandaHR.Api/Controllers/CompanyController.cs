using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

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
        public async Task<ActionResult<Company>> Create(Company company)
        {
            //if (ModelState.IsValid)
            //{
            await _companyService.Add(company);

            return Ok(company);
            //}
            //else
            //{
            //    return ValidationProblem();
            //}
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _companyService.GetAllAsync();
        }

        [HttpPut]
        public async Task<ActionResult<Company>> Update(Company company)
        {
            if (company == null)
            {
                return BadRequest("owner object is null");
            }

            bool doesExist = _companyService.GetById(company.Id).Result != null;

            if (!doesExist)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            await _companyService.Update(company);

            return Ok(company);
            //}
            //else
            //{
            //    return ValidationProblem();
            //}
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(Guid id)
        {
            Company deletedCompany = await _companyService.GetById(id);

            if (deletedCompany == null)
            {
                return NotFound(id);
            }

            await _companyService.Remove(deletedCompany);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetById(Guid id)
        {
            Company givenCompany = await _companyService.GetById(id);

            if (givenCompany == null)
            {
                return NotFound(id);
            }

            return new ObjectResult(givenCompany);
        }

        [HttpDelete("Users")]
        public async Task<ActionResult<UserCompany>> RemoveUserFromCompany(UserCompany userCompany)
        {
            await _companyService.RemoveUserFromCompany(userCompany);

            return Ok(userCompany);
        }

        [HttpDelete("Cities")]
        public async Task<ActionResult<CompanyCity>> RemoveCompanyFromCities(CompanyCity companyCity)
        {
            await _companyService.RemoveCompanyFromCity(companyCity);

            return Ok(companyCity);
        }

        [HttpPost("Users")]
        public async Task<ActionResult<UserCompany>> AddUserToCompany(UserCompany userCompany)
        {
            await _companyService.AddUserInCompany(userCompany);

            return Ok(userCompany);
        }

        [HttpPost("Cities")]
        public async Task<ActionResult<CompanyCity>> AddCompanyToCity(CompanyCity companyCity)
        {
            await _companyService.AddCompanyInCity(companyCity);

            return Ok(companyCity);
        }
    }
}