using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;

        public CVService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            var cvs = await _uow.CVs
                  .GetAllAsync(include: v => v
                      .Include(s => s.JobExperiences)
                      .Include(s => s.Qualification)
                      .Include(s => s.SkillKnowledges)
                      .Include(s => s.User));

            return cvs;
        }
    }
}
