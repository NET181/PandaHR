using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICRUDservice<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Remove(Guid id);
    }
}
