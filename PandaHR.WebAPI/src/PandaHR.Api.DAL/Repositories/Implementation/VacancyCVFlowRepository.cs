using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
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

        public async Task<IEnumerable<VacancyCVFlowDTO>> GetAllFlowsByVacancyId(Guid vacancyId)
        {
            var flows = await _context.VacancyCVFlows.Where(v =>
                 v.VacancyId == vacancyId)
                .Select(c => new VacancyCVFlowDTO()
                {
                    CVId = c.CVId,
                    VacancyId = c.VacancyId,
                    Status = c.Status,
                    Notes = c.Notes
                }).ToListAsync();

            return flows;
        }
    }
}
