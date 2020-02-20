using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using PandaHR.Api.DAL.MongoDB.Entities;

namespace PandaHR.Api.DAL.MongoDB
{
    public class FileService : IFileService
    {
        private readonly IMongoCollection<NoSQLFile> _files;

        public FileService(IConfiguration configuration)
        {
            string connectionString = configuration["MongoBDConnectionString"];
            var connection = new MongoUrlBuilder(connectionString);
            
            // get MongoDB client
            MongoClient client = new MongoClient(connectionString);
            
            // get database access
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);

            // get Files collection
            _files = database.GetCollection<NoSQLFile>("Files");
        }
        
        public async Task<IEnumerable<NoSQLFile>> GetFiles(string name)
        {
            // filter builder
            var builder = new FilterDefinitionBuilder<NoSQLFile>();
            var filter = builder.Empty; // get all documents
            // filter by FileName
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

        public async Task Create(Guid id, Stream fileStream, string fileName)
        {
            NoSQLFile p = new NoSQLFile();

            p.Content = new byte[fileStream.Length];
            await fileStream.ReadAsync(p.Content);

            p.Name = fileName;
            p.BaseEntityGuid = id;
            await Create(p);
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
            if (file != null)
            {
                return file.Content;
            }

            return new byte[0];
        }

        #region debug method
        public async Task StoreDirect()
        {
            string filePath = @"d:\tests\";
            string fileName = "HelloWorld.docx";
            
            using (var fileStream = new FileStream(filePath + fileName, FileMode.Open))
            {
                NoSQLFile p = new NoSQLFile();
                p.Content = new byte[fileStream.Length];
                await fileStream.ReadAsync(p.Content);
                
                fileStream.Close();

                p.Name = fileName;
                p.BaseEntityGuid = Guid.NewGuid();
                await Create(p);
            }
        }
        #endregion
    }
}
