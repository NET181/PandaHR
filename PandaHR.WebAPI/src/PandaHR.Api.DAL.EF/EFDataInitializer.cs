using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.EF.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.EF
{
    public class EFDataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public EFDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();
        }
    }
}
