using MongoDB.Driver;

namespace Common.Infrastructure.MongoDB
{
    public interface IMongoDbClientProvider
    {
        MongoClient Client { get; }
    }
}
