using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task Add(User entity)
        {
            return _uow.Users.Add(entity);
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

        public async Task<User> GetById(Guid id, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null)
        {
            var user = await _uow.Users.GetAllAsync(include: source => source
            .Include(c => c.City)
            .Include(e => e.Educations)
                .ThenInclude(d => d.Degree)
            .Include(e => e.Educations)
                .ThenInclude(d => d.Speciality)
            .Include(cv => cv.CVs)
            .Include(v => v.Vacancies),
            predicate: u => u.Id == id
            ).Fir ;
            return user;
        }

        public IEnumerable<Education> GetEducations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SkillKnowledge> GetSkills()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
