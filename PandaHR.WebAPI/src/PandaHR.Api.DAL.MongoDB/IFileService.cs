using System.IO;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.MongoDB
{
    public interface IFileService
    {
        Task StoreFile(string id, Stream fileStream, string fileName);
    }
}
