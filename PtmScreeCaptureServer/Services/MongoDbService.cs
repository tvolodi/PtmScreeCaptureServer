using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PtmScreeCaptureServer.Model;

namespace PtmScreeCaptureServer.Services
{
    public class MongoDbService
    {
        //private readonly IMongoCollection<TDocument> mongoCollection;

        private MongoDatabaseBase _database;

        public MongoDbService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            var _database = mongoClient.GetDatabase(options.Value.DatabaseName);

        }

        public async Task<List<T>> GetAsync<T>()
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var result = await collection.Find(_ => true).ToListAsync<T>();

            return result;            
        }

        public async Task<T> GetAsync<T>(ObjectId id) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var result = await collection.Find(d => d.Id == id).FirstOrDefaultAsync<T>();

            return result;
        }

        public async System.Threading.Tasks.Task InsertAsync<T>(T doc) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            await collection.InsertOneAsync(doc);
        }

        public async System.Threading.Tasks.Task UpdateAsync<T>(ObjectId id, T doc) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var result = await collection.ReplaceOneAsync(d => d.Id == id, doc);
        }

        public async System.Threading.Tasks.Task DeleteAsync<T>(ObjectId id) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            await collection.DeleteOneAsync(d => d.Id == id);
        }



    }
}
