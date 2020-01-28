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

        public async Task<IEnumerable<Company>> GetWhereAsync(Expression<Func<Company, bool>> predicate)
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

        public async Task RemoveAsync(Company company)
        {
            await _uow.Companies.RemoveAsync(company);
        }

        public async Task UpdateAsync(Company company) 
        {
            await _uow.Companies.UpdateAsync(company);
        }

        public async Task<Company> GetByIdAsync(Guid Id)
        {
            return await _uow.Companies.GetFirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task AddAsync(Company company)
        {
            await _uow.Companies.AddAsync(company);
        }

        public async Task RemoveUserFromCompanyAsync(UserCompany userCompany)
        {
            await _uow.CompanyUsers.RemoveAsync(userCompany);
        }

        public async Task AddUserToCompanyAsync(UserCompany userCompany)
        {
            await _uow.CompanyUsers.AddAsync(userCompany);
        }

        public async Task AddCompanyToCityAsync(CompanyCity companyCity)
        {
            await _uow.CityCompanies.AddAsync(companyCity);
        }

        public async Task RemoveCompanyFromCityAsync(CompanyCity companyCity)
        {
            await _uow.CityCompanies.RemoveAsync(companyCity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var companyToRemove = await _uow.Companies.GetFirstOrDefaultAsync(c => c.Id == id);
            await RemoveAsync(companyToRemove);
        }
        //TO DO
        //DTOs
    }
}
