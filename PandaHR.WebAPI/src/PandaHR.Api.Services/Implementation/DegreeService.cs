using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class DegreeService : IAsyncService<Degree>, IDegreeService
    {
        private readonly IUnitOfWork _uow;

        public DegreeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(Degree entity)
        {
            await _uow.Degrees.Add(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var degree = await GetByIdAsync(id);
            await RemoveAsync(degree);
        }

        public async Task RemoveAsync(Degree entity)
        {
            await _uow.Degrees.Remove(entity);
        }

        public async Task<IEnumerable<Degree>> GetAllAsync()
        {
            return await _uow.Degrees.GetAllAsync();
        }

        public async Task<Degree> GetByIdAsync(Guid id)
        {
            return await _uow.Degrees.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Degree entity)
        {
            await _uow.Degrees.Update(entity);
        }
    }
}
