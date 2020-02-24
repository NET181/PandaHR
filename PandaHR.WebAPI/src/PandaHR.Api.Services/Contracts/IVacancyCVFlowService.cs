using System;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.VacancyCVFlow;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.Vacancy;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyCVFlowService : IAsyncService<VacancyCVFlow>
    {
        Task<VacancyCVFlow> AddAsync(VacancyCVFlowCreationServiceModel vacancyCVFlow);
        Task ChangeStatus(VacancyCVFlowEditStatusServiceModel vacancyCVFlow);
        string GetFlowStatusAsync(Guid CVId, Guid vacancyId);
    }
}
