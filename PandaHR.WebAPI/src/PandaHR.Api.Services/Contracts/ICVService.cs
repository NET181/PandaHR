using PandaHR.Api.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService
    {
        void Add(CV cv);
        void Remove(CV cv);
        void Update(CV cv);
        Task<CV> GetById(Guid id);
    }
}
