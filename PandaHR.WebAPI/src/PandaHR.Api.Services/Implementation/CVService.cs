using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;
        private readonly IElasticClient _elasticClient;

        public CVService(IUnitOfWork uow, IElasticClient elasticClient)
        {
            _uow = uow;
            _elasticClient = elasticClient;
        }

        public async Task AddAsync(CV entity)
        {
            await _uow.CVs.Add(entity);
            await _elasticClient.IndexDocumentAsync(entity);
        }

        public async Task<IEnumerable<CV>> GetAllAsync()
        {
            return await _uow.CVs.GetAllAsync();
        }

        public async Task<CV> GetByIdAsync(Guid id)
        {
            return await _uow.CVs.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var jobExperience = await GetByIdAsync(id);
            await RemoveAsync(jobExperience);
        }

        public async Task RemoveAsync(CV entity)
        {
            await _uow.CVs.Remove(entity);
            await _elasticClient.DeleteAsync<CV>(entity);
        }

        public async Task UpdateAsync(CV entity)
        {
            await _uow.CVs.Update(entity);
            await _elasticClient.UpdateAsync<CV>(entity, u => u.Doc(entity));
        }
    }
}
