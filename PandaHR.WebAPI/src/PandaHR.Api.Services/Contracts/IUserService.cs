using PandaHR.Api.DAL.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
