using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class SpecialityService : IAsyncService<Speciality>, ISpecialityService
    {
        private readonly IUnitOfWork _uow;

        public SpecialityService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(Speciality entity)
        {
            await _uow.Specialities.AddAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var speciality = await GetByIdAsync(id);
            await RemoveAsync(speciality);
        }

        public async Task RemoveAsync(Speciality entity)
        {
            await _uow.Specialities.Remove(entity);
        }

        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            return await _uow.Specialities.GetAllAsync();
        }

        public async Task<Speciality> GetByIdAsync(Guid id)
        {
            return await _uow.Specialities.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Speciality entity)
        {
            await _uow.Specialities.Update(entity);
        }
    }
}
