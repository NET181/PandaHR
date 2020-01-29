using System;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
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

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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
