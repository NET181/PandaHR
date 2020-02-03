using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.Vacancy;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.SkillRequirement;
using PandaHR.Api.Services.Models.Vacancy;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVacancy(VacancyCreationRequestModel vacancy)
        {
            ICollection<SkillRequirementServiceModel> skillRequirements = new List<SkillRequirementServiceModel>();
            skillRequirements.Add(new SkillRequirementServiceModel()
            {
                SkillId = new Guid("477c595a-3188-476a-a4a5-7611bae371cd"),
                ExperienceId = new Guid("561d468e-a93b-4e6b-a576-52b3d7bbf32a"),
                KnowledgeLevelId = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"),
                Weight = 5
            });
            //var vacancyServiceModel = _mapper.Map<VacancyCreationRequestModel, VacancyServiceModel>(vacancy);
            VacancyServiceModel vacancyServiceModel = new VacancyServiceModel()
            {
                UserId = new Guid("b072e561-9258-4502-8b40-c545b121cb0c"),
                CompanyId = new Guid("53653054-750e-4ed8-a636-db00ee728b15"),
                Description = "newSummary",
                IsActive = true,
                QualificationId = new Guid("6331e0ea-9df6-4e20-9bed-b18382b180bd"),
                TechnologyId = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e"),
                CityId = new Guid("619619FF-8B86-D011-B42D-00CF4FC964FF"),
                SkillRequirements = skillRequirements 
            };
            await _vacancyService.AddAsync(vacancyServiceModel);

            return Ok();
        }
    }
}
