using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class UserRole : IMongoDocument
    {
        public ObjectId Id { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
    }
}
