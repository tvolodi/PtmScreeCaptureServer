using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PtmScreeCaptureServer.Model;

namespace PtmScreeCaptureServer.Services
{
    public class StartupService : IHostedService
    {
        private List<string> mongoCollectionNames = new List<string>
        {
            "UserRole",
            "User",
            "WorkTask",
        };
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Check Mongo DB collections

            var mongoClient = new MongoClient("mongodb://localhost:27017");

            var _database = mongoClient.GetDatabase("PtmScreenCapture");

            foreach (string collName in mongoCollectionNames)
            {
                var collection = _database.GetCollection<IMongoDocument>(collName);
                if(collection == null)
                {
                    await _database.CreateCollectionAsync(collName);
                }
            }


        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            
        }
    }
}
