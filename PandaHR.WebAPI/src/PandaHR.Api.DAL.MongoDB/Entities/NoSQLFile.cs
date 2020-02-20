using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PandaHR.Api.DAL.MongoDB.Entities
{
    public class NoSQLFile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid BaseEntityGuid { get; set; }
        DateTime AddedDate { set; get; }
        DateTime ModifiedDate { set; get; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
