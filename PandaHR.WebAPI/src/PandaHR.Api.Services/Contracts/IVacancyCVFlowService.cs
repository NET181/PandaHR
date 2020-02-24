using System;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services.Contracts
{
    public interface IVacancyCVFlowService : IAsyncService<VacancyCVFlow>
    {
        string GetFlowStatusAsync(Guid CVId, Guid vacancyId);
    }
}
