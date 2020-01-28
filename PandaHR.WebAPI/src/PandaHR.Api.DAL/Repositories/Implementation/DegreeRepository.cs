using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class DegreeRepository : EFRepositoryAsync<Degree>, IDegreeRepository
    {
        private readonly ApplicationDbContext _context;

        public DegreeRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }
    }
}
