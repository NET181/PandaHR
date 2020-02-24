using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.VacancyCVFlow;

namespace PandaHR.Api.Services.Implementation
{
    public class VacancyCVFlowService : IAsyncService<VacancyCVFlow>, IVacancyCVFlowService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public VacancyCVFlowService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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

        public async Task<IEnumerable<VacancyCVFlowServiceModel>> GetAllFlowsByVacancyIdAsync(Guid vacancyId)
        {
            var flowDTO = await _uow.VacancyCVFlows.GetAllFlowsByVacancyId(vacancyId);

            var flowSeviceModel = _mapper.Map<IEnumerable<VacancyCVFlowDTO>,
                    IEnumerable<VacancyCVFlowServiceModel>>(flowDTO);

            return flowSeviceModel;
        }
    }
}
