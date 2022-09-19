using MongoDB.Bson;

namespace PtmScreeCaptureServer.Model
{
    public class WorkTaskTimeTrack
    { 

        public WorkTask WorkTask { get; set; } = new WorkTask();

        public DateTimeOffset StartDT { get; set; } = new DateTimeOffset();
        public DateTimeOffset StopDT { get; set; } = new DateTimeOffset();

        public TimeSpan WorkPeriod { get; set; }
    }
}
