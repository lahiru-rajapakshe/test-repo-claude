using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Common.Infrastructure.Configuration;

namespace Common.Infrastructure.MongoDB
{
    public class MongoDBClientProvider : IMongoDbClientProvider
    {
        private Lazy<MongoClient> _client;

        public MongoDBClientProvider(IOptions<MongoConfig> mongoConfig)
        {
            _client = new Lazy<MongoClient>(() => new MongoClient(mongoConfig.Value.ConnectionString));
        }

        public MongoClient Client => _client.Value;
    }
}
