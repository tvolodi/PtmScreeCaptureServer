using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class TeamMember : IMongoDocument
    {
        public ObjectId Id { get; set; }

        public User User { get; set; } = new User();

        public List<WorkTaskTimeTrack> workTaskTimeTracks { get; set; } = new List<WorkTaskTimeTrack>();

        
    }
}
