using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.VacancyCVFlow;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyCVFlowService : IAsyncService<VacancyCVFlow>
    {
        Task<IEnumerable<VacancyCVFlowServiceModel>> GetAllFlowsByVacancyIdAsync(Guid vacancyId);
    }
}
