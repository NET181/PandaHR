using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PandaHR.Api.DAL.MongoDB.Entities;

namespace PandaHR.Api.DAL.MongoDB
{
    public interface IFileService
    {
        Task Create(Guid id, Stream fileStream, string fileName);
        Task Create(NoSQLFile p);
        Task<IEnumerable<NoSQLFile>> GetFiles(string Name);
        Task<IEnumerable<NoSQLFile>> GetFiles(Guid BaseEntityGuid);
        Task<IEnumerable<NoSQLFile>> GetFiles(Dictionary<string, string> filterCriteria);
        Task<NoSQLFile> GetFile(string id);
        Task<byte[]> GetFileAsBytes(string id);
        Task<bool> IsDocumentExist(string id);
        Task<DeleteResult> Remove(string id);

    }
}
