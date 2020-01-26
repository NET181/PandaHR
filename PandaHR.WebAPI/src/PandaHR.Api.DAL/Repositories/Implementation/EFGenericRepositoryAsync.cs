using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class EFGenericRepositoryAsync<T> : EFRepositoryAsync<T>, IAsyncRepositoryGeneric<T> where T : class, IBaseEntity
    {
        public EFGenericRepositoryAsync(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<T> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool ignoreQueryFilters = false)
        {
            var query = _dbSet.Where(t => t.Id == id);

            if (include != null)
            {
                query = include(query);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
