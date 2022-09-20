using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PtmScreeCaptureServer.Model;

namespace PtmScreeCaptureServer.Services
{
    public class MongoDbService
    {
        //private readonly IMongoCollection<TDocument> mongoCollection;

        private IMongoDatabase _database;

        public MongoDbService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _database = mongoClient.GetDatabase(options.Value.DatabaseName);

        }

        public async Task<List<T>> GetAsync<T>() where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var result = await collection.Find(d => d.IsDeleted == false).ToListAsync<T>();
            if(result == null)
            {
                result = new List<T>(); 
            }
            return result;            
        }

        public async Task<T> GetAsync<T>(string id) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var result = await collection.Find(d => d.Id == id && d.IsDeleted == false).FirstOrDefaultAsync<T>();

            return result;
        }

        public async System.Threading.Tasks.Task InsertAsync<T>(T doc) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            await collection.InsertOneAsync(doc);
        }

        public async System.Threading.Tasks.Task UpdateAsync<T>(string id, T doc) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var result = await collection.ReplaceOneAsync(d => d.Id == id, doc);
        }

        public async System.Threading.Tasks.Task DeleteAsync<T>(string id) where T : IMongoDocument
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(typeof(T).Name);

            var doc = await collection.Find(d => d.Id == id && d.IsDeleted == false).FirstOrDefaultAsync();
            if(doc != null)
            {
                doc.IsDeleted = true;
                await collection.ReplaceOneAsync(d => d.Id == id, doc);
            }
            
        }



    }
}
