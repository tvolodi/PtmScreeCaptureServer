using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class UserWorkJournal : BaseDocument
    { 
        public User User { get; set; } = new User();
        public WorkTask WorkTask { get; set; } = new WorkTask();

        public DateTimeOffset StartDT { get; set; } = new DateTimeOffset();
        public DateTimeOffset StopDT { get; set; } = new DateTimeOffset();
    }
}
