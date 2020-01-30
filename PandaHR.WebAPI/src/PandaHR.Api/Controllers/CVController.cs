using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private readonly ICVService _cvService;

        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        public async Task<CV> Get(Guid cvId)
        {
            var jobExperience = await _cvService.GetByIdAsync(cvId);

            return jobExperience;
        }

        [HttpDelete]
        public void Remove(CV cv)
        {
            _cvService.RemoveAsync(cv);
        }

        [HttpPut]
        public void Update(CV cv)
        {
            _cvService.UpdateAsync(cv);
        }

        [HttpPost]
        public void Add(CV cv)
        {
            _cvService.AddAsync(cv);
        }
    }
}