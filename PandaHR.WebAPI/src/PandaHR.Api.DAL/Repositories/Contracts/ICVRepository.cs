using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.Models.Entities;
using PandaHR.Api.DAL.DTOs.CV;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ICVRepository : IAsyncRepository<CV>
    {
        Task<IEnumerable<CVSummaryDTO>> GetUserCVSummaryAsync(Guid userId, int? pageSize = 10, int? page = 1);
        Task<IEnumerable<CVforSearchDTO>> GetCVsAsync(Expression<Func<CV, bool>> predicate, int? pageSize = 10, int? page = 1);
    }
}
