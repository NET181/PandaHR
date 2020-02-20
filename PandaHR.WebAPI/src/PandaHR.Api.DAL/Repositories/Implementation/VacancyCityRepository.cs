using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class VacancyCityRepository : EFRepositoryAsync<VacancyCity>, IVacancyCityRepository
    {
        public VacancyCityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
