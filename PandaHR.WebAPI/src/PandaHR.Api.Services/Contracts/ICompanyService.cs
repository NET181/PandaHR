using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICompanyService : IAsyncService<Company>
    {
        Task<IEnumerable<Company>> GetWhereAsync(Expression<Func<Company, bool>> predicate);
        Task RemoveUserFromCompanyAsync(UserCompany userCompany);
        Task AddUserToCompanyAsync(UserCompany userCompany);
        Task AddCompanyToCityAsync(CompanyCity companyCity);
        Task RemoveCompanyFromCityAsync(CompanyCity companyCity);
        Task<ICollection<CompanyBasicInfoServiceModel>> GetCompaniesByNameAutoFillByString(string name);
    }
}
