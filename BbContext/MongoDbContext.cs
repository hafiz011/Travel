using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Flyjaatra.BbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Define your custom domain collections
        //public IMongoCollection<ServiceItem> ServiceItems => _database.GetCollection<ServiceItem>("ServiceItems");
    }
}
