using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.Services.Models;
using PandaHR.Api.Services.Models.CV;
using System;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService
    {
        Task AddAsync(CVServiceModel cvServiceModel);
    }
}
