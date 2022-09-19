using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class WorkTask : IMongoDocument
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = "";
    }
}
