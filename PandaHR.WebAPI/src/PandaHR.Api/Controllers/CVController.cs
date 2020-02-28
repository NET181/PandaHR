using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Models.SkillKnowledge;
using PandaHR.Api.Models.JobExperience;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Models.JobExperience;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>CVController</c> class.
/// Contains action methods for <c>CV</c>.
/// <list type="bullet">
/// <item>
/// <term>GetCVsByVacancySkillSet</term>
/// <description>Get CVs matching by vacancy skill set</description>
/// </item>
/// <item>
/// <term>ExportCv</term>
/// <description>Export CV as .docx</description>
/// </item>
/// <item>
/// <term>GetUserCV</term>
/// <description>Get CV for user</description>
/// </item>
/// <item>
/// <term>AddSkillKnowledgeToCV</term>
/// <description>Add skill knowledge</description>
/// </item>
/// <item>
/// <term>DeleteSkillKnowledgeFromCV</term>
/// <description>Delete skill knowledge</description>
/// </item>
/// <item>
/// <term>AddJobExperienceToCV</term>
/// <description>Add job experience to CV</description>
/// </item>
/// <item>
/// <term>DeleteJobExperienceFromCV</term>
/// <description>Remove job experience from CV</description>
/// </item>
/// <item>
/// <term>GetUserCVSummary</term>
/// <description>Get user CV summary</description>
/// </item>
/// <item>
/// <term>GetVacanciesForCV</term>
/// <description>Get vacancies for CV</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing CV</description>
/// </item>
/// <item>
/// <term>Put</term>
/// <description>Update existing CV</description>
/// </item>
/// <item>
/// <term>Post</term>
/// <description>Create CV</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private IMapper _mapper;
        private readonly ICVService _cvService;
        private readonly IWebHostEnvironment _env;

        public CVController(IMapper mapper, ICVService cvService, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _cvService = cvService;
            _env = env;
        }

         /// <summary>
        /// Get CVs by vacancy skill set with <paramref name="threshold" /> match.
        /// </summary>
        /// <returns>
        /// Not Found if vacancy not found, CVs set if success or NoContent if CVs not found
        /// </returns>
        /// <param name="threshold">Marching percent.</param>
        /// <param name="vacancyId">Vacancy ID.</param>
        [HttpGet("/GetCVsByVacancy/{vacancyId}/threshold={threshold}")]
        public async Task<IActionResult> GetCVsByVacancySkillSet(Guid vacancyId, int threshold)
        {
            try
            {
                var result = await _cvService.GetCVsByVacancy(vacancyId, threshold);

                if (result.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Export CVs as a <paramref name="type"/>.
        /// </summary>
        /// <returns>
        /// Export result
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="type">Type for export.</param>
        [HttpGet("{id}/export/{type}")]
        public async Task<IActionResult> ExportCv(Guid id, string type = "docx")
        {
            var file = await _cvService.ExportCVAsync(id, _env.WebRootPath, type);

            return File(file.FileContents, file.ContentType, file.FileName);
        }

        /// <summary>
        /// Get CV of concrete user.
        /// </summary>
        /// <returns>
        /// CV
        /// </returns>
        /// <param name="userId">User ID.</param>
        [HttpGet("/UserCVExt/{userId}")]
        public async Task<IActionResult> GetUserCV(Guid userId)
        {
            return Ok(await _cvService.GetUserCVAsync(userId));
        }

        /// <summary>
        /// Add skill knowledge to CV.
        /// </summary>
        /// <returns>
        /// OK status
        /// </returns>
        /// <param name="model">Knowledge to add.</param>
        /// <param name="id">ID.</param>
        [HttpPost("/CV/{id}/AddSkillKnowledge")]
        public async Task<IActionResult> AddSkillKnowledgeToCV(SkillKnowledgeRequestModel model, Guid id)
        {
            var mappedModel = _mapper.Map<SkillKnowledgeRequestModel, SkillKnowledgeServiceModel>(model);

            try
            {
                await _cvService.AddSkillKnowledgeToCVAsync(mappedModel, id);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Remove skill knowledge from CV.
        /// </summary>
        /// <returns>
        /// OK status
        /// </returns>
        /// <param name="SkillId">Knowledge ID.</param>
        /// <param name="CVId">ID.</param>
        [HttpDelete("/CV/{CVId}/DeleteSkillKnowledge/{SkillId}")]
        public async Task<IActionResult> DeleteSkillKnowledgeFromCV(Guid SkillId, Guid CVId)
        {
            try
            {
                await _cvService.DeleteSkillKnowledgeFromCVAsync(SkillId, CVId);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary> 
        /// Add job experience to CV.
        /// </summary>
        /// <returns>
        /// OK status
        /// </returns>
        /// <param name="model">Job experiene to add.</param>
        /// <param name="id">ID.</param>
        [HttpPost("/CV/{id}/AddJobExperience")]
        public async Task<IActionResult> AddJobExperienceToCV(JobExperienceRequestModel model, Guid id)
        {
            var mappedModel = _mapper.Map<JobExperienceRequestModel, JobExperienceServiceModel>(model);

            try
            {
                await _cvService.AddJobExperienceToCVAsync(mappedModel, id);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        
        /// <summary>
        /// Remove job experience from CV.
        /// </summary>
        /// <returns>
        /// OK status
        /// </returns>
        /// <param name="JobExperienceId">Experience ID.</param>
        /// <param name="CVId">ID.</param>
        [HttpDelete("/CV/{CVId}/DeleteJobExperience/{JobExperienceId}")]
        public async Task<IActionResult> DeleteJobExperienceFromCV(Guid JobExperienceId, Guid CVId)
        {
            try
            {
                await _cvService.DeleteJobExperienceFromCVAsync(JobExperienceId, CVId);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/UserCVsSummary/5
        /// <summary>
        /// Get CV summary of concrete user.
        /// </summary>
        /// <returns>
        /// CV summary or NotFound status
        /// </returns>
        /// <param name="userId">User ID.</param>
        [HttpGet("/UserCVSummary/{userId}")]
        public async Task<IActionResult> GetUserCVSummary(Guid userId)
        {
            var item = await _cvService.GetUserCVPreviewAsync(userId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // GET: api/UserCVsSummary/5
        /// <summary>
        /// Get CV summary by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// CV summary
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpGet("/CVSummary", Name = "GetCVSummary")]
        public async Task<IActionResult> GetCVSummary(Guid id)
        {
            return Ok(await _cvService.GetByIdAsync(id));
        }

        [HttpGet("/CreatedCV", Name = "CreatedCV")]
        public IActionResult CreatedCV(CVServiceModel cv)
        {
            return Ok(_cvService.GetByIdAsync(cv.Id));
        }

        // GET: api/VacanciesForCV/5
        /// <summary>
        /// Get vacancies for CV.
        /// </summary>
        /// <returns>
        /// CV summary or NotFound status
        /// </returns>
        /// <param name="CVId">User ID.</param>
        [HttpGet("/VacanciesForCV/{CVId}")]
        public async Task<IActionResult> GetVacanciesForCV(Guid CVId, int page = 1, int pageSize = 10)
        {
            var item = await _cvService.GetVacanciesForCV(CVId, page, pageSize);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // DELETE: api/CV/5
        /// <summary>
        /// Remove CV by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code or NotFound if no CVs with such ID.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _cvService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _cvService.RemoveAsync(id);

            return Ok();
        }

        // PUT: api/CV
          /// <summary>
        /// Update CV from <paramref name="cv"/>.
        /// </summary>
        /// <returns>
        /// Ok status code or BadRequest if CV is null.
        /// </returns>
        /// <param name="cv">Request body.</param>
        [HttpPut]
        public async Task<IActionResult> Put(CVCreationRequestModel cv)
        {
            if (cv == null)
            {
                return BadRequest();
            }

            var cvServiceModel = _mapper.Map<CVCreationRequestModel, CVCreationServiceModel>(cv);
            await _cvService.UpdateAsync(cvServiceModel);

            return Ok();
        }

        // POST: api/CV
        /// <summary>
        /// Create CV from <paramref name="cv"/>.
        /// </summary>
        /// <returns>
        /// Ok status code or BadRequest if CV is null.
        /// </returns>
        /// <param name="cv">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> Post(CVCreationRequestModel cv)
        {
            if (cv == null)
            {
                BadRequest();
            }

            var cvServiceModel = _mapper.Map<CVCreationRequestModel, CVCreationServiceModel>(cv);
            var createdCV = await _cvService.AddAsync(cvServiceModel);

            CreatedResult result = new CreatedResult("CreatedCV", createdCV);
            return result;
            //return CreatedAtRoute("GetCVSummary", new { id = createdCV.Id }, createdCV);
        }
    }
}
