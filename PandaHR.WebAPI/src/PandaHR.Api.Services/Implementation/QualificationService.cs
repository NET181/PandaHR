using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.DTOs.Qualification;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Models.Qualification;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.Services.Implementation
{
    public class QualificationService : IQualificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public QualificationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QualificationServiceModel>> GetAllQualificationsAsync()
        {
            var dto = await _uow.Qualifications.GetQualificationDTOsAsync();

            return _mapper.Map<ICollection<QualificationDTO>, ICollection<QualificationServiceModel>>(dto);
        }

        public async Task<Qualification> AddAsync(Qualification qualification)
        {
            var res = await _uow.Qualifications.AddAsync(qualification);
            await _uow.SaveChangesAsync();

            return res;
        }

        public async Task RemoveAsync(Guid id)
        {
            var qualification = await GetByIdAsync(id);
            await RemoveAsync(qualification);
        }

        public async Task RemoveAsync(Qualification qualification)
        {
            _uow.Qualifications.Remove(qualification);
            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<Qualification>> GetAllAsync()
        {
            var qualifications = await _uow.Qualifications.GetAllAsync();

            return qualifications;
        }

        public async Task<Qualification> GetByIdAsync(Guid id)
        {
            return await _uow.Qualifications.GetFirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Qualification qualification)
        {
            _uow.Qualifications.Update(qualification);
            await _uow.SaveChangesAsync();
        }
    }
}
