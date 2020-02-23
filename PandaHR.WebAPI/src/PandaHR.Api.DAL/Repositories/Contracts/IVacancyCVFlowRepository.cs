using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IVacancyCVFlowRepository : IAsyncRepository<VacancyCVFlow>
    {
        Task<VacancyCVFlow> AddAsync(VacancyCVFlowCreationDTO vacancyCVFlow);
        Task Patch(VacancyCVFlowEditStatusDTO flow);
    }
}
