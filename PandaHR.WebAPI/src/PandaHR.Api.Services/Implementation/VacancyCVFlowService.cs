using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;

namespace PandaHR.Api.Services.Implementation
{
    public class VacancyCVFlowService : IAsyncService<VacancyCVFlow>, IVacancyCVFlowService
    {
        private readonly IUnitOfWork _uow;

        public VacancyCVFlowService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(VacancyCVFlow entity)
        {
            await _uow.VacancyCVFlows.AddAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var vacancyCVFlow = await GetByIdAsync(id);
            await RemoveAsync(vacancyCVFlow);
        }

        public async Task RemoveAsync(VacancyCVFlow entity)
        {
            await _uow.VacancyCVFlows.Remove(entity);
        }

        public async Task<IEnumerable<VacancyCVFlow>> GetAllAsync()
        {
            return await _uow.VacancyCVFlows.GetAllAsync();
        }

        public async Task<VacancyCVFlow> GetByIdAsync(Guid id)
        {
            return await _uow.VacancyCVFlows.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(VacancyCVFlow entity)
        {
            await _uow.VacancyCVFlows.Update(entity);
        }
    }
}
