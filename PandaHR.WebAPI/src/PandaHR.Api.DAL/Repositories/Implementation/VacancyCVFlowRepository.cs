using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.VacancyCVFlow;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class VacancyCVFlowRepository : EFRepositoryAsync<VacancyCVFlow>, IVacancyCVFlowRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VacancyCVFlowRepository(ApplicationDbContext context,
            IMapper mapper) :
            base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyCVFlow> AddAsync(VacancyCVFlowCreationDTO vacancyCVFlow)
        {
            VacancyCVFlow flow = _mapper.Map<VacancyCVFlowCreationDTO, VacancyCVFlow>(vacancyCVFlow);
            await _context.VacancyCVFlows.AddAsync(flow);
            await _context.SaveChangesAsync();

            return flow;
        }
    }
}
