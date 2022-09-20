using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PtmScreeCaptureServer.Model
{
    public class BaseDocument : IMongoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
