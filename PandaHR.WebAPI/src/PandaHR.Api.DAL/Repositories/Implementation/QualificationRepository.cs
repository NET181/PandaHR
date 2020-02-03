using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.Qualification;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.Repositories.Contracts;

namespace PandaHR.Api.DAL.Repositories.Implementation
{
    public class QualificationRepository : EFRepositoryAsync<Qualification>, IQualificationRepository
    {
        private readonly ApplicationDbContext _context;

        public QualificationRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public async Task<ICollection<QualificationDTO>> GetQualificationDTOsAsync()
        {
            var dtos = await _context.Experiences.Select(q => new QualificationDTO()
            {
                Id = q.Id,
                Name = q.Name,
                Value = q.Value
            }).ToListAsync();

            return dtos;
        }
    }
}
