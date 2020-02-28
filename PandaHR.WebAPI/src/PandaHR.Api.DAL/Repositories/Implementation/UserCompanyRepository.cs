using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class UserCompanyRepository : EFRepositoryAsync<UserCompany>, IUserCompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public UserCompanyRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }
    }
}
