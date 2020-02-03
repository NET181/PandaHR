using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class UserRepository : EFRepositoryAsync<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<UserDTO> GetUserInfo(Guid id)
        {
            IQueryable<UserDTO> query = _context.Users.AsQueryable()
                .Where(u => u.Id == id)
                .Select(u => new UserDTO()
            {
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                Email = u.Email,
                Phone = u.PhoneNumber
            });

            UserDTO user = await query.FirstOrDefaultAsync();

            return user;
        }
    }
}
