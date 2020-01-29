using Microsoft.EntityFrameworkCore;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace PandaHR.Api.Services.Implementation
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _uow;
        private readonly IElasticClient _elasticClient;

        public CVService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async void Add(CV cv)
        {
            await _uow.CVs.Add(cv);

            //if (_uow.CVs.Exists)
            //    await _elasticClient.UpdateAsync<CV>(cv, u => u.Doc(cv));
            //else
                await _elasticClient.IndexDocumentAsync(cv);
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
