using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.CV;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService : IAsyncService<CV>
    {
        public Task<IList<CVforSearchDTO>> GetUserCVsPreviewAsync(Guid userId, int? pageSize, int? page);
    }
}
