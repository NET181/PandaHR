using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using PandaHR.Api.DAL.Models;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IAsyncRepositoryGeneric <T> : IAsyncRepository<T> where T: class, IBaseEntity
    {
        Task<T> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                            bool ignoreQueryFilters = false);
    }
}
