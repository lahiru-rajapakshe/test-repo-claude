using StackExchange.Redis;
using System.Text.Json;

namespace Common.Infrastructure.Infrastructure.Redis
{
    public class RedisRepository<T> : IRedisRepository<T>
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = _redis.GetDatabase();
        }

        public async Task<T?> GetDataAsync(string key)
        {
            var data = await _database.StringGetAsync(key);

            if (data.IsNullOrEmpty)
                return default;

            return JsonSerializer.Deserialize<T>(data);
        }
        public async Task<IEnumerable<string>> GetAllKeysAsync()
        {
            var server = _redis.GetServer(_redis.GetEndPoints().First());
            return server.Keys().Select(k => k.ToString());
        }

        public async Task SetDataAsync(string key, T data, TimeSpan? absoluteExpirationRelativeToNow = null)
        {

            var serializedData = JsonSerializer.Serialize(data);

            // Set the data in Redis with an optional expiration time
            await _database.StringSetAsync(key, serializedData, absoluteExpirationRelativeToNow);
        }

        public async Task<bool> DeleteDataAsync(string key)
        {

            return await _database.KeyDeleteAsync(key);
        }

        public async Task<bool> UpdateDataAsync(string key, T data, TimeSpan? absoluteExpirationRelativeToNow = null)
        {


            if (await _database.KeyExistsAsync(key))
            {
                var serializedData = JsonSerializer.Serialize(data);
                return await _database.StringSetAsync(key, serializedData, absoluteExpirationRelativeToNow);
            }

            return false; // Key doesn't exist
        }

        public async Task<bool> PatchDataAsync(string key, object partialData)
        {

            var existingData = await _database.StringGetAsync(key);

            if (existingData.IsNullOrEmpty)
                return false;

            var existingObject = JsonSerializer.Deserialize<T>(existingData);

            if (existingObject == null)
                return false;

            // Merge existing object with partial data (using reflection or custom logic)
            foreach (var property in partialData.GetType().GetProperties())
            {
                var existingProperty = typeof(T).GetProperty(property.Name);
                if (existingProperty != null && existingProperty.CanWrite)
                {
                    existingProperty.SetValue(existingObject, property.GetValue(partialData));
                }
            }

            // Save the merged object back to Redis
            var serializedData = JsonSerializer.Serialize(existingObject);
            await _database.StringSetAsync(key, serializedData);

            return true;
        }

    }
}
