using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.City;
using PandaHR.Api.DAL.DTOs.Company;
using PandaHR.Api.DAL.DTOs.Education;
using PandaHR.Api.DAL.DTOs.User;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

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
                        ICollection<EducationWithDetailsDTO>>(u.Educations)
                });

            UserFullInfoDTO user = await query.FirstOrDefaultAsync();

            Task<List<CompanyWithDetailsDTO>> companies = _context.Users.AsQueryable()
               .Include(u => u.UserCompanies)
               .SelectMany(a => a.UserCompanies)
               .Where(a => a.UserId == id)
               .Select(c => new CompanyWithDetailsDTO()
               {
                   Id = c.CompanyId,
                   Name = c.Company.Name
               }).ToListAsync();

            user.Companies = companies.Result;

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

        public async Task<UserDTO> AddAsync(UserCreationDTO user)
        {
            User result = await AddAsync(_mapper.Map<UserCreationDTO, User>(user));
            return _mapper.Map<User, UserDTO>(result);
        }

        public async Task<UserFullInfoDTO> AddAsync(UserFullInfoDTO user)
        {
            var result = await AddAsync(_mapper.Map<UserFullInfoDTO, User>(user));
            return _mapper.Map<User, UserFullInfoDTO>(result);
        }

        public async Task<ICollection<Education>> AddEducationsNoExistAsync(
                ICollection<EducationWithDetailsDTO> educations, 
                Guid userId)
        {
 
            IQueryable<EducationWithDetailsDTO> userEducations = _context.Educations.AsQueryable()
                 .Where(c => c.UserId == userId)
                 .Select(c => new EducationWithDetailsDTO()
                 {
                     Speciality = c.Speciality.Name,
                     DegreeId = c.DegreeId,
                     PlaceName = c.PlaceName,
                     DateEnd = c.DateEnd,
                     DateStart = c.DateStart
                 });

            var missedEducations = educations.Except(userEducations);
            List<Education> eds =
                _mapper.Map<ICollection<EducationWithDetailsDTO>, ICollection<Education>>(educations).ToList();

            foreach(var education in eds)
            {
                education.UserId = userId;
            }

            await _context.Educations.AddRangeAsync(eds);
            await _context.SaveChangesAsync();

            return eds;
        }
    }
}
