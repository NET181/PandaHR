using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class VacancyRepository : EFRepositoryAsync<Vacancy>, IVacancyRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<Vacancy> GetByIdWithSkillRequestAsync(Guid Id)
        {
            return await _context.Set<Vacancy>().FindAsync(Id);
        }
    }
}
