using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetAllAsync();
        public Task<IEnumerable<Company>> GetWhere(Expression<Func<Company, bool>> predicate);
        public Task Remove(Company company);
        public Task Update(Company company);
        public Task<Company> GetById(Guid Id);
        public Task Add(Company company);
  
    }
}
