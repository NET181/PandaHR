using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.SkillKnowledge;
using PandaHR.Api.Services.Models.User;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private IMapper _mapper;
        private readonly ICVService _cvService;

        public CVController(IMapper mapper, ICVService cvService)
        {
            _mapper = mapper;
            _cvService = cvService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
               // await _cvService.RemoveAsync(id);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CV cv)
        {
            try
            {
              //  await _cvService.UpdateAsync(cv);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CVCreationRequestModel cv)
        {
            try
            {
                cv.User = new UserCreationServiceModel()
                {
                    FirstName = "timuuuuuuur8",
                    SecondName = "mirzaieeeeeeeeeev",
                    Email = "asfafssafasf8@gmail.com",
                    Phone = "1234512345"
                };

                cv.QualificationId = new Guid("a76428b1-aac5-410b-af4f-811c9b474997");
                cv.TechnologyId = new Guid("f43f4b05-6cb1-4c72-9ebb-1fe5fd1fc62e");
                cv.SkillKnowledges = new Collection<SkillKnowledgeServiceModel>();

                cv.SkillKnowledges.Add(new SkillKnowledgeServiceModel()
                    {
                        ExperienceId = new Guid("561d468e-a93b-4e6b-a576-52b3d7bbf32a"),
                        KnowledgeLevelId = new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"),
                        SkillId = new Guid("503661d4-297f-4e3d-f1cb-08d7a67ce45d")
                    });

                var cvServiceModel = _mapper.Map<CVCreationRequestModel, CVServiceModel>(cv);
                await _cvService.AddAsync(cvServiceModel);

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    
    }
}