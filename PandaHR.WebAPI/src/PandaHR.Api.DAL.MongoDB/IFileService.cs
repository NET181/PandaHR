using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandaHR.Api.DAL.MongoDB.Entities;

namespace PandaHR.Api.DAL.MongoDB
{
    public interface IFileService
    {
        Task StoreFile(Guid id, Stream fileStream, string fileName);
        Task Create(NoSQLFile p);
        Task<IEnumerable<NoSQLFile>> GetFiles(string name);
        Task<NoSQLFile> GetFile(string id);
        Task<byte[]> GetFileAsBytes(string id);
    }
}
