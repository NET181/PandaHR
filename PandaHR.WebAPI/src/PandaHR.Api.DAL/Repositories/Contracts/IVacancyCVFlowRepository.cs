using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Models.Entities.Enums;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IVacancyCVFlowRepository : IAsyncRepository<VacancyCVFlow>
    {
        Task<VacancyCVFlow> AddAsync(VacancyCVFlowCreationDTO vacancyCVFlow);
        Task Patch(VacancyCVFlowEditStatusDTO flow);
        VacancyCVStatus GetFlowStatusAsync(Guid CVId, Guid vacancyId);
        Task<IEnumerable<VacancyCVFlowDTO>> GetAllFlowsByVacancyId(Guid vacancyId);
    }
}
