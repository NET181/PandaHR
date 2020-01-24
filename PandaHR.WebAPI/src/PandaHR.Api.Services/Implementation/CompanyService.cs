using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;

        public CompanyService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _uow.Companies.GetAllAsync(include: source => source
            .Include(v=> v.Vacancies)
            .Include(cc=>cc.CompanyCities)
                .ThenInclude(c=>c.City)
                .ThenInclude(c=>c.Country)
            .Include(uc=>uc.UserCompanies)
                .ThenInclude(u=>u.User));

            return companies;
        }
    }
}
