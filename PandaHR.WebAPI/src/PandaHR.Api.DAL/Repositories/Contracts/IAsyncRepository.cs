using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}
