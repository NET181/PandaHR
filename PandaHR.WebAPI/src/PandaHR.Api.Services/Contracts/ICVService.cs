using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService : IAsyncService<CVServiceModel>
    {
        Task AddAsync(CVServiceModel cvServiceModel);
    }
}
