using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class QualificationService
    {
        private readonly IUnitOfWork _uow;

        public QualificationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(Qualification qualification)
        {
            await _uow.Qualifications.Add(qualification);
        }

        public async Task<IEnumerable<Qualification>> GetAllAsync()
        {
            return await _uow.Qualifications.GetAllAsync();
        }

        public async Task<Qualification> GetByIdAsync(Guid id)
        {
            return (await _uow.Qualifications.GetWhere(s => s.Id == id)).FirstOrDefault();
        }

        public async Task RemoveAsync(Guid id)
        {
            var qualification = (await _uow.Qualifications.GetWhere(s => s.Id == id)).FirstOrDefault();
            if (qualification != null)
            {
                await _uow.Qualifications.Remove(qualification);
            }
        }

        public async Task UpdateAsync(Qualification qualification)
        {
            if (qualification != null)
            {
                await _uow.Qualifications.Update(qualification);
            }
        }
    }
}
