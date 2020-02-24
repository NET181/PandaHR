using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Vacancy;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.VacancyCVFlow;

namespace PandaHR.Api.Services.Implementation
{
    public class VacancyCVFlowService : IAsyncService<VacancyCVFlow>, IVacancyCVFlowService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public VacancyCVFlowService(IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<VacancyCVFlow> AddAsync(VacancyCVFlow entity)
        {
            var res = await _uow.VacancyCVFlows.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return res;
        }

        public async Task RemoveAsync(Guid id)
        {
            var vacancyCVFlow = await GetByIdAsync(id);
            await RemoveAsync(vacancyCVFlow);
        }

        public async Task RemoveAsync(VacancyCVFlow entity)
        {
            _uow.VacancyCVFlows.Remove(entity);
            await _uow.SaveChangesAsync();
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
            _uow.VacancyCVFlows.Update(entity);
            await _uow.SaveChangesAsync();
        }

        public string GetFlowStatusAsync(Guid CVId, Guid vacancyId)
        {
            return _uow.VacancyCVFlows.GetFlowStatusAsync(CVId, vacancyId).ToString();
        }

        public async Task<VacancyCVFlow> AddAsync(VacancyCVFlowCreationServiceModel vacancyCVFlow)
        {
            var flow = _mapper.Map<VacancyCVFlowCreationServiceModel, VacancyCVFlowCreationDTO>(vacancyCVFlow);
            var addedFlow = await _uow.VacancyCVFlows.AddAsync(flow);
            
            return addedFlow;
        }

        public async Task ChangeStatus(VacancyCVFlowEditStatusServiceModel vacancyCVFlow)
        {
            var flow = _mapper.Map<VacancyCVFlowEditStatusServiceModel, VacancyCVFlowEditStatusDTO>(vacancyCVFlow);
            await _uow.VacancyCVFlows.Patch(flow);
        }
    }
}
