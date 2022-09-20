using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class WorkTask : BaseDocument
    {
        public string Name { get; set; } = "";
    }
}
