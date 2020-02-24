using System;
using PandaHR.Api.DAL.Models.Entities.Enums;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IVacancyCVFlowRepository : IAsyncRepository<VacancyCVFlow>
    {
        VacancyCVStatus GetFlowStatusAsync(Guid CVId, Guid vacancyId);
    }
}
