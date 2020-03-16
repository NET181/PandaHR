using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Models.KnowledgeLevel;
using PandaHR.Api.Models.Skill;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.KnowledgeLevel;
using PandaHR.Api.Services.Models.Skill;

namespace PandaHR.Api.Controllers
{
/// <summary>
/// The <c>SkillController</c> class.
/// Contains action methods for <c>Skill</c>.
/// <list type="bullet">
/// <item>
/// <term>Get</term>
/// <description>Get all skills</description>
/// </item>
/// <item>
/// <term>Get</term>
/// <description>Get skill by ID</description>
/// </item>
/// <item>
/// <term>GetSkillsByTermToSearchAsync</term>
/// <description>Get skill by term using autofill</description>
/// </item>
/// <item>
/// <term>PostAsync</term>
/// <description>Create new skill</description>
/// </item>
/// <item>
/// <term>PutAsync</term>
/// <description>Update existing skill</description>
/// </item>
/// <item>
/// <term>Delete</term>
/// <description>Remove existing skill</description>
/// </item>
/// <item>
/// <term>GetSkillNames</term>
/// <description>Get all skill names</description>
/// </item>
/// <item>
/// <term>GetKnowledgeLevelsBySkillId</term>
/// <description>Get skill knowledges by skill ID</description>
/// </item>
/// </list>
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all skills.
        /// </summary>
        /// <returns>
        /// The set of all skills or NotFound status if there is no skills.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable <SkillResponseModel> skills;
            skills= _mapper.Map<IEnumerable<SkillServiceModel>, IEnumerable<SkillResponseModel>>(
                await _skillService.GetAllAsync());

            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
        }

        // GET: api/skills/names
        /// <summary>
        /// Get all skill names.
        /// </summary>
        /// <returns>
        /// The set of all skill names or NotFound status if there is no skill names.
        /// </returns>
        [HttpGet("names")]
        public async Task<IActionResult> GetSkillNames()
        {
            var skillNamesServiceModels = await _skillService.GetSkillNames();
            var responseModels = _mapper
                .Map<ICollection<SkillNameServiceModel>, ICollection<SkillNameResponseModel>>(skillNamesServiceModels);
           
            if (responseModels != null)
            {
                return Ok(responseModels);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get skill by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Skill having given ID or NotFound status if no skills with such ID.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var skill = await _skillService.GetByIdAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

         /// <summary>
        /// Get knowledge levels for skill with <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Set of skill knowledges or NotFound status if skill have not it.
        /// </returns>
        /// <param name="id">ID.</param>
        [HttpGet("{id}/knowledgelevels")]
        public async Task<IActionResult> GetKnowledgeLevelsBySkillId(Guid id)
        {
            var knowledgeLevelServiceModels = await _skillService.GetKnowledgeLevelsBySkill(id);
            var responseModels = _mapper
                .Map<ICollection<KnowledgeLevelServiceModel>, ICollection<KnowledgeLevelResponseModel>>(knowledgeLevelServiceModels);

            if (responseModels != null)
            {
                return Ok(responseModels);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get skills by string <paramref name="term"/> using autofill.
        /// </summary>
        /// <returns>
        /// Skills set with names due to term using autofill or NotFound status skills set is null.
        /// </returns>
        /// <param name="term">String for autofill.</param>
        [HttpGet("autofill/{term}")]
        public async Task<IActionResult> GetSkillsByTermToSearchAsync(string term)
        {
            var skillNamesServiceModels = await _skillService.GetSkillNamesByTerm(term);
            var responseModels = _mapper
                .Map<ICollection<SkillNameServiceModel>, ICollection<SkillNameResponseModel>>(skillNamesServiceModels);
            
            if (responseModels != null)
            {
                return Ok(responseModels);
            }
            else
            {
                return NotFound();
            }
        }

         /// <summary>
        /// Create new skill from <paramref name="skill"/>.
        /// </summary>
        /// <returns>
        /// Ok status code.
        /// </returns>
        /// <param name="skill">Request body.</param>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SkillCreationModel skill)
        {
            await _skillService.AddAsync(_mapper.Map<SkillCreationModel,SkillServiceModel>(skill));

            return Ok();
        }

         /// <summary>
        /// Update skill by <paramref name="id"/> from <paramref name="skill"/>.
        /// </summary>
        /// <returns>
        /// Ok status code if successfully updated or NotFound status if there is no skills with such id.
        /// </returns>
        /// <param name="id">ID.</param>
        /// <param name="skill">Request body.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]SkillCreationModel skill)
        {
            var item = await _skillService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _skillService.UpdateAsync(_mapper.Map<SkillCreationModel, SkillServiceModel>(skill));

            return Ok();
        }

         /// <summary>
        /// Remove skill by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Ok status code if successfully deleted or NotFound status if there is no skills with such id.
        /// </returns>
        /// <param name="id">GUID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var skill = await _skillService.GetByIdAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            await _skillService.RemoveAsync(skill);

            return Ok();
        }
    }
}
