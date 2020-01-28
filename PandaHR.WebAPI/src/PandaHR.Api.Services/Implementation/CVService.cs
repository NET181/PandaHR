using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
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

        public void Add(CV cv)
        {
            _uow.CVs.Add(cv);
        }

        public async Task<CV> GetById(Guid id)
        {
            var cv = await _uow.CVs.GetById(id);

            return cv;
        }

        public void Remove(CV cv)
        {
            _uow.CVs.Remove(cv);
        }

        public void Update(CV cv)
        {
            _uow.CVs.Update(cv);
        }
    }
}
