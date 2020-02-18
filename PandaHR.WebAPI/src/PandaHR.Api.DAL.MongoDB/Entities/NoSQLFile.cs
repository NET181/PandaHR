using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PandaHR.Api.DAL.MongoDB.Entities
{
    public class NoSQLFile
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid BaseEntityGuid { get; set; }
        DateTime AddedDate { set; get; }
        DateTime ModifiedDate { set; get; }

        public string FileId { get; set; }

        public bool HasFile()
        {
            return !String.IsNullOrWhiteSpace(FileId);
        }
    }
}
