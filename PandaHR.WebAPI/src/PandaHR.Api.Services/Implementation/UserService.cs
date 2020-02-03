using System;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Services.Models.User;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.Services.Models.Company;
using PandaHR.Api.DAL.DTOs.Company;

namespace PandaHR.Api.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task AddAsync(User entity)
        {
            await _uow.Users.Add(entity);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _uow.Users.GetAllAsync(include: source => source
            .Include(c => c.City)
            .Include(e => e.Educations)
                .ThenInclude(d => d.Degree)
            .Include(e => e.Educations)
                .ThenInclude(d => d.Speciality)
            .Include(cv => cv.CVs)
            .Include(v => v.Vacancies));

            return users;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _uow.Users.GetByIdAsync(id);
        }

        public async Task<ICollection<CompanyNameServiceModel>> GetUserCompanies(Guid userId)
        {
            var serviceModels = await _uow.Companies.GetCompanyNamesByUserId(userId);

            return _mapper.Map<ICollection<CompanyNameDTO>, ICollection<CompanyNameServiceModel>>(serviceModels);
        }

        public async Task<UserServiceModel> GetUserInfo(Guid id)
        {
            UserDTO userDTO = await _uow.Users.GetUserInfo(id);
            UserServiceModel userServiceModel = _mapper.Map<UserDTO, UserServiceModel>(userDTO);

            return userServiceModel;
        }

        public async Task<UserServiceModel> GetUserInfo(Guid id)
        {
            UserDTO userDTO = await _uow.Users.GetUserInfo(id);
            UserServiceModel userServiceModel = _mapper.Map<UserDTO, UserServiceModel>(userDTO);

            return userServiceModel;
        }

        public async Task RemoveAsync(Guid id)
        {
            var city = await _uow.Users.GetByIdAsync(id);
            await _uow.Users.Remove(city);
        }

        public async Task RemoveAsync(User user)
        {
            await _uow.Users.Remove(user);
        }

        public async Task UpdateAsync(User entity)
        {
            await _uow.Users.Update(entity);
        }
    }
}
