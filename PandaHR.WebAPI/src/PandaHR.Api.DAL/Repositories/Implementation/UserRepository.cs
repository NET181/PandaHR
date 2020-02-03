using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class UserRepository : EFRepositoryAsync<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper, ApplicationDbContext context) :
            base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserFullInfoDTO> GetFullUserInfo(Guid id)
        {
            IQueryable<UserFullInfoDTO> query = _context.Users.AsQueryable()
                .Include(u => u.Educations)
                .Include(u => u.City)
                .Where(u => u.Id == id)
                .Select(u => new UserFullInfoDTO()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    FirstName = u.FirstName,
                    SecondName = u.SecondName,
                    City = new CityDTO()
                    {
                        Id = u.City.Id,
                        Name = u.City.Name
                    },
                    Educations = _mapper.Map<ICollection<Education>, 
                        ICollection<EducationDTO>>(u.Educations)
                });

            var user = await query.FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserDTO> GetUserInfo(Guid id)
        {
            IQueryable<UserDTO> query = _context.Users.AsQueryable()
                .Where(u => u.Id == id)
                .Select(u => new UserDTO()
            {
                Id = u.Id,
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
