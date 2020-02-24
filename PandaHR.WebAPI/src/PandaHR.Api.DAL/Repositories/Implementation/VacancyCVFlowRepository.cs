using System;
using System.Linq;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Models.Entities.Enums;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class VacancyCVFlowRepository : EFRepositoryAsync<VacancyCVFlow>, IVacancyCVFlowRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyCVFlowRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public VacancyCVStatus GetFlowStatusAsync(Guid CVId, Guid vacancyId)
        {
            var flow = _context.VacancyCVFlows
                .Where(t=> t.CVId == CVId && t.VacancyId == vacancyId).FirstOrDefault();
            if (flow != null)
            {
                return flow.Status;
            }

            return VacancyCVStatus.NotExists;
        }
    }
}
