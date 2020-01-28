using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICompanyService : IAsyncService<Company>
    {
        public Task<IEnumerable<Company>> GetWhereAsync(Expression<Func<Company, bool>> predicate);
        public Task RemoveUserFromCompanyAsync(UserCompany userCompany);
        public Task AddUserToCompanyAsync(UserCompany userCompany);
        public Task AddCompanyToCityAsync(CompanyCity companyCity);
        public Task RemoveCompanyFromCityAsync(CompanyCity companyCity);
    }
}
