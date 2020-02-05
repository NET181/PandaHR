using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.Experience;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class ExperienceRepository : EFRepositoryAsync<Experience>, IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExperienceRepository(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<ExperienceDTO>> GetExperienceDTOsAsync()
        {
            var dtos = await _context.Experiences.Select(e => new ExperienceDTO()
            {
                Id = e.Id,
                Name = e.Name,
                Value = e.Value
            }).ToListAsync();

            return dtos;
        }
    }
 }
        
