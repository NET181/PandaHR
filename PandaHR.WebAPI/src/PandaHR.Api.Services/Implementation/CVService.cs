using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;

        public CVService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task AddAsync(CV entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CV>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CV> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(CV entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CV entity)
        {
            throw new NotImplementedException();
        }
    }
}
