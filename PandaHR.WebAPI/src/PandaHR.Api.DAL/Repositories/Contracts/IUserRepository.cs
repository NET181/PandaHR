using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<UserDTO> GetUserInfo(Guid id);
        Task<UserFullInfoDTO> GetFullUserInfo(Guid id);
        Task<UserDTO> AddAsync(UserCreationDTO user);
    }
}
