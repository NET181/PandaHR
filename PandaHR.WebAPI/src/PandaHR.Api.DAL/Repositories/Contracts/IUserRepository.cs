using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<UserDTO> GetUserInfo(Guid id);
        Task<UserFullInfoDTO> GetFullUserInfo(Guid id);
        Task<UserDTO> AddAsync(UserCreationDTO user);
        Task<UserFullInfoDTO> AddAsync(UserFullInfoDTO user);
        Task<ICollection<Education>> AddEducationsNoExistAsync(ICollection<EducationWithDetailsDTO> educationToAdd, Guid userId);
    }
}
