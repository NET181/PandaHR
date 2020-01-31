using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Models.CV;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.CV;
using PandaHR.Api.Services.Models.User;
using System;
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
                    FirstName = "timuuuuuuur",
                    SecondName = "mirzaieeeeeeeeeev",
                    Email = "asfafssafasf@gmail.com",
                    Phone = "1234512345"
                };

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