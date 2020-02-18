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
        private readonly IMongoCollection<NoSQLFile> Files;

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
            Files = database.GetCollection<NoSQLFile>("Files");
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

            return await Files.Find(filter).ToListAsync();
        }
        
        public async Task<NoSQLFile> GetFile(string id)
        {
            return await Files.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        
        public async Task Create(NoSQLFile p)
        {
            await Files.InsertOneAsync(p);
        }
        
        public async Task Update(NoSQLFile p)
        {
            await Files.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        
        public async Task Remove(string id)
        {
            await Files.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
        
        public async Task<byte[]> GetFileAsBytes(string id)
        {
            return await gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }
        
        public async Task StoreFile(string id, Stream fileStream, string fileName)
        {
            NoSQLFile p = await GetFile(id);
            if (p.HasFile())
            {
                await gridFS.DeleteAsync(new ObjectId(p.FileId));
            }
            
            ObjectId fileId = await gridFS.UploadFromStreamAsync(fileName, fileStream);
           
            p.FileId = fileId.ToString();
            var filter = Builders<NoSQLFile>.Filter.Eq("_id", new ObjectId(p.Id));
            var update = Builders<NoSQLFile>.Update.Set("FileId", p.FileId);
            await Files.UpdateOneAsync(filter, update);
        }
    }
}
