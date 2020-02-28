using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models.Company;
using PandaHR.Api.Services.Models.User;

namespace PandaHR.Api.Services.Contracts
{
    public interface IUserService : IAsyncService<User>
    {
        Task<UserServiceModel> GetUserInfo(Guid id);
        Task<ICollection<CompanyNameServiceModel>> GetUserCompanies(Guid userId);
        Task<UserFullInfoServiceModel> GetFullInfoById(Guid id);
    }
}
