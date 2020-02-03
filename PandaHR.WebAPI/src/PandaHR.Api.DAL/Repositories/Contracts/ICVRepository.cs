using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL.Models.Entities;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface ICVRepository : IAsyncRepository<CV>
    {
        Task AddAsync(CVDTO cv);
    }
}