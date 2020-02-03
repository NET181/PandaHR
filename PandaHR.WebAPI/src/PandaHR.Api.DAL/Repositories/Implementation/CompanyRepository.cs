using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
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
        private readonly IMapper _mapper;

        public CompanyRepository(IMapper mapper, ApplicationDbContext context) :
            base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<CompanyBasicInfoDTO>> GetCompaniesByNameAutofillByString(string name)
        {
            var test = await _context.Companies.ToListAsync();

            IQueryable<CompanyBasicInfoDTO> query = _context.Companies.AsQueryable()
                .Where(c => Microsoft.EntityFrameworkCore.EF.Functions.Like(c.Name, $"%{name}%"))
                .Select(c => new CompanyBasicInfoDTO()
                {
                    Id = c.Id,
                    Name = c.Name
                }); 

            var companiesDto = await query.ToListAsync();

            return companiesDto;
        }
    }
}
