using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.JobExperience;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class JobExperienceRepository: EFRepositoryAsync<JobExperience>, IJobExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        public JobExperienceRepository(ApplicationDbContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<JobExperience> GetById(Guid id)
        {
            var jobExperience = await _context.JobExperiences.Where(j => j.Id == id).FirstAsync();

            return jobExperience;
        }
    }
}
