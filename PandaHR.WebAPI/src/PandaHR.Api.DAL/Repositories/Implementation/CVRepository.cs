using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class CVRepository : EFRepositoryAsync<CV>, ICVRepository
    {
        private readonly ApplicationDbContext _context;

        public CVRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<CV> GetById(Guid id)
        {
            var jobExperience = await _context.CVs.Where(j => j.Id == id).FirstAsync();
            return jobExperience;
        }
    }
}
