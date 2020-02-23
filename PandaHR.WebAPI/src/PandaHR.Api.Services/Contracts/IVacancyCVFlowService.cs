using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.VacancyCVFlow;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyCVFlowService : IAsyncService<VacancyCVFlow>
    {
        Task<VacancyCVFlow> AddAsync(VacancyCVFlowCreationServiceModel vacancyCVFlow);
    }
}
