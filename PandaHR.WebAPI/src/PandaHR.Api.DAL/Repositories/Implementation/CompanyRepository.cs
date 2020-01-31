using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class CompanyRepository : EFRepositoryAsync<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<CompanyNameDTO>> GetCompanyNamesByUserId(Guid userId)
        {
            var dtos = await _context.Companies.Where(c => 
            c.UserCompanies.Any(uc=> uc.UserId == userId))
                .Select(c => new CompanyNameDTO()
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

            return dtos;
        }
    }
}
