using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class UserRole : BaseDocument
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
    }
}
