using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ICompanyRepository: IAsyncRepository<Company>
    {
        Task<ICollection<CompanyNameDTO>> GetCompanyNamesByUserId(Guid userId);
        Task<ICollection<CompanyBasicInfoDTO>> GetCompaniesByNameAutofillByString(string name);
    }
}
