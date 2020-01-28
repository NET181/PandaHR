using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class SpecialityRepository : EFRepositoryAsync<Speciality>, ISpecialityRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialityRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }
    }
}
