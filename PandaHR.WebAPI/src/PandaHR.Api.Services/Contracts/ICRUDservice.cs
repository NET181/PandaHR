using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICRUDservice<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Remove(Guid id);
    }
}
