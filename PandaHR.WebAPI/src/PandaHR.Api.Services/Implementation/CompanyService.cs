using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

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
                .ThenInclude(u=>u.User),
            orderBy: source => source
            .OrderBy(company => company.Name)
                .ThenBy(company => company));         

            return companies;
        }

        public async Task<IEnumerable<Company>> GetWhere(Expression<Func<Company, bool>> predicate)
        {
            var companies = await _uow.Companies.GetAllAsync(include: source => source
            .Include(v=> v.Vacancies)
            .Include(cc=>cc.CompanyCities)
                .ThenInclude(c=>c.City)
                .ThenInclude(c=>c.Country)
            .Include(uc=>uc.UserCompanies)
                .ThenInclude(u=>u.User),
            orderBy: source => source
            .OrderBy(company => company.Name)
                .ThenBy(company => company),
            predicate: predicate);

            return companies;
        }

        public async Task Remove(Company company)
        {
            //удалять будем только хрень, которую по ошибке добавили и без каких-либо связей
            await _uow.Companies.Remove(company);
        }

        public async Task Update(Company company) 
        {
            await _uow.Companies.Update(company);
        }

        public async Task<Company> GetById(Guid Id)
        {
            return await _uow.Companies.GetById(Id);
        }

        public async Task Add(Company company)
        {
            await _uow.Companies.Add(company);
        }
    }
}
