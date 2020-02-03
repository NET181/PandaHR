using PandaHR.Api.Services.Models.CV;
using System.Threading.Tasks;

namespace PandaHR.Api.Services.Contracts
{
    public interface ICVService : IAsyncService<CVServiceModel>
    {
        Task AddAsync(CVServiceModel cvServiceModel);
    }
}
