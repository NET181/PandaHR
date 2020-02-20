using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
