using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Company;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Company;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>CompanyController</c> class.
/// Contains action methods for <c>Company</c>.
/// <list type="bullet">
/// <item>
/// <term>GetAsync</term>
/// <description>Get all companies</description>
/// </item>
/// <item>
/// <term>GetByIdAsync</term>
/// <description>Get company by ID</description>
/// </item>
/// <item>
/// <term>CreateAsync</term>
/// <description>Create new company</description>
/// </item>
/// <item>
/// <term>UpdateAsync</term>
/// <description>Update existing company</description>
/// </item>
/// <item>
/// <term>DeleteAsync</term>
/// <description>Remove existing company</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        /// <summary>
        /// Create new company from <paramref name="company"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="company">Request body.</param>
        [HttpPost]
        public async Task<ActionResult<Company>> CreateAsync(Company company)
        {
            await _companyService.AddAsync(company);

            return Ok(company);
        }

         /// <summary>
        /// Get all companies.
        /// </summary>
        /// <returns>
        /// The set of all companies.
        /// </returns>
        [HttpGet]
        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _companyService.GetAllAsync();
        }

         /// <summary>
        /// Update company from <paramref name="company"/>.
        /// </summary>
        /// <returns>
        /// Bad Request status if company is null, Not Found status if company does not exists, Ok status if succes.
        /// </returns>
        /// <param name="company">Request body.</param>
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
            await _companyService.UpdateAsync(company);

            return Ok(company);
        }

         /// <summary>
        /// Remove company by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteAsync(Guid id)
        {
            await _companyService.RemoveAsync(id);

            return Ok(id);
        }

         /// <summary>
        /// Get companies by string <paramref name="name"/> using autofill.
        /// </summary>
        /// <returns>
        /// Companies set with names due to term using autofill or NotFound status company set is null.
        /// </returns>
        /// <param name="name">String for autofill.</param>
        [HttpGet]
        [Route("autofill/{name}")]
        public async Task<ActionResult<ICollection<CompanyBasicInfoResponse>>> GetByName(string name)
        {
            var companies = await _companyService.GetCompaniesByNameAutoFillByString(name);

            var companiesResponse = _mapper.Map<ICollection<CompanyNameServiceModel>, 
                ICollection<CompanyBasicInfoResponse>>(companies);

            return Ok(companiesResponse);
        }

        /// <summary>
        /// Get company by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Company by ID or NotFound status if no companies with such ID.
        /// </returns>
        /// <param name="id">ID.</param>
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

        [HttpDelete("Users")]
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
    }
}