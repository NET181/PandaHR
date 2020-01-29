using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class QualificationService : IQualificationService
    {
        private readonly IUnitOfWork _uow;

        public QualificationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(Qualification qualification)
        {
            await _uow.Qualifications.Add(qualification);
        }

        public async Task RemoveAsync(Guid id)
        {
            var qualification = await GetByIdAsync(id);
            await RemoveAsync(qualification);
        }

        public async Task RemoveAsync(Qualification qualification)
        {
            await _uow.Qualifications.Remove(qualification);
        }

        public async Task<IEnumerable<Qualification>> GetAllAsync()
        {
            return await _uow.Qualifications.GetAllAsync();
        }

        public async Task<Qualification> GetByIdAsync(Guid id)
        {
            return await _uow.Qualifications.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Qualification qualification)
        {
            await _uow.Qualifications.Update(qualification);
        }
    }
}
