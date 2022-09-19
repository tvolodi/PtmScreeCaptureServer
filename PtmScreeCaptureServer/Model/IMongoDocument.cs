using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public interface IMongoDocument
    {
        public ObjectId Id { get; set; }
    }
}
