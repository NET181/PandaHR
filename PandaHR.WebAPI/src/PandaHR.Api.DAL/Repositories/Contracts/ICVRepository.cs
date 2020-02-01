using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.CV;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ICVRepository : IAsyncRepository<CV>
    {
        Task<IList<CVforSearchDTO>> GetUserCVsAsync(Guid userId, int? pageSize = 10, int? page = 1);
    }
}
