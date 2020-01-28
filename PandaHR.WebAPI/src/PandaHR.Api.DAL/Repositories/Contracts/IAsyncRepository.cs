using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                   bool disableTracking = true,
                                   bool ignoreQueryFilters = false);
      
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                       bool disableTracking = true,
                                       bool ignoreQueryFilters = false);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<T> GetById(params object[] keyValues);

        //Task InsertAsync(params T[] entities) => _dbSet.AddRangeAsync(entities);
    }
}
