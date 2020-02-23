using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Models.Company;

namespace PandaHR.Api.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CompanyService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
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
            await _uow.Companies.Remove(company);
        }

        public async Task UpdateAsync(Company company) 
        {
            await _uow.Companies.Update(company);
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
            await _uow.UserCompanies.Remove(userCompany);
        }

        public async Task AddUserToCompanyAsync(UserCompany userCompany)
        {
            await _uow.UserCompanies.AddAsync(userCompany);
        }

        public async Task AddCompanyToCityAsync(CompanyCity companyCity)
        {
            await _uow.CompanyCities.AddAsync(companyCity);
        }

        public async Task RemoveCompanyFromCityAsync(CompanyCity companyCity)
        {
            await _uow.CompanyCities.Remove(companyCity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var companyToRemove = await _uow.Companies.GetFirstOrDefaultAsync(c => c.Id == id);
            await RemoveAsync(companyToRemove);
        }

        public async Task<ICollection<CompanyBasicInfoServiceModel>> GetCompaniesByNameAutoFillByString(string name)
        {
            var companiesDto = await _uow.Companies.GetCompaniesByNameAutofillByString(name);

            var companiesServiceModel = _mapper.Map<ICollection<CompanyBasicInfoDTO>,
                    ICollection<CompanyBasicInfoServiceModel>>(companiesDto);

            return companiesServiceModel;
        }
    }
}
