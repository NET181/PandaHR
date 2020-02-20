using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using PandaHR.Api.DAL.MongoDB.Entities;

namespace PandaHR.Api.DAL.MongoDB
{
    public class FileService : IFileService
    {
        IGridFSBucket gridFS;
        private readonly IMongoCollection<NoSQLFile> _files;

        public FileService(IConfiguration configuration)
        {
            // строка подключения
            //string connectionString = "mongodb://localhost:27017/mobilestore";
            string connectionString = configuration["MongoBDConnectionString"];
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
            // обращаемся к коллекции
            _files = database.GetCollection<NoSQLFile>("Files");
        }
        
        public async Task<IEnumerable<NoSQLFile>> GetFiles(string name)
        {
            // строитель фильтров
            var builder = new FilterDefinitionBuilder<NoSQLFile>();
            var filter = builder.Empty; // фильтр для выборки всех документов
            // фильтр по имени
            if (!String.IsNullOrWhiteSpace(name))
            {
                filter = filter & builder.Regex("Name", new BsonRegularExpression(name));
            }

            return await _files.Find(filter).ToListAsync();
        }
        
        public async Task<NoSQLFile> GetFile(string id)
        {
            return await _files.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        
        public async Task Create(NoSQLFile p)
        {
            await _files.InsertOneAsync(p);
        }
        
        public async Task Update(NoSQLFile p)
        {
            await _files.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        
        public async Task Remove(string id)
        {
            await _files.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }

        public async Task<byte[]> GetFileAsBytes(string id)
        {
            var file = await _files.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
            byte[] result = await gridFS.DownloadAsBytesAsync(new ObjectId(id));
            return result;
            
        }

        public async Task StoreFile(Guid id, Stream fileStream, string fileName)
        {
            NoSQLFile p = new NoSQLFile();
            //if (p.HasFile())
            //{
            //    await gridFS.DeleteAsync(new ObjectId(p.FileId));
            //}

            ObjectId fileId = await gridFS.UploadFromStreamAsync(fileName, fileStream);

            p.Id = fileId.ToString();

            if ((await GetFile(p.Id)) == null)
            {
                p.Name = fileName;
                p.BaseEntityGuid = id;
                await Create(p);
            }
            else
            {
                var filter = Builders<NoSQLFile>.Filter.Eq("_id", new ObjectId(p.Id));
                var update = Builders<NoSQLFile>.Update.Set("Id", p.Id);
                var result = await _files.UpdateOneAsync(filter, update);
                var updatedCount = result.MatchedCount;
            }
        }
    }
}
