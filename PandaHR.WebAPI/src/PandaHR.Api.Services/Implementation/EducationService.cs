using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class EducationService : IAsyncService<Education>, IEducationService
    {
        private readonly IUnitOfWork _uow;

        public EducationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(Education entity)
        {
            await _uow.Educations.Add(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var education = await GetByIdAsync(id);
            await RemoveAsync(education);
        }

        public async Task RemoveAsync(Education entity)
        {
            await _uow.Educations.Remove(entity);
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _uow.Educations.GetAllAsync();
        }

        public async Task<Education> GetByIdAsync(Guid id)
        {
            return await _uow.Educations.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Education entity)
        {
            await _uow.Educations.Update(entity);
        }
    }
}
