namespace Common.Infrastructure.Infrastructure.Redis
{
    public interface IRedisRepository<T>
    {
        Task<T?> GetDataAsync(string key);
        Task SetDataAsync(string key, T data, TimeSpan? absoluteExpirationRelativeToNow = null);
        Task<bool> DeleteDataAsync(string key);
        Task<bool> UpdateDataAsync(string key, T data, TimeSpan? absoluteExpirationRelativeToNow = null);
        Task<bool> PatchDataAsync(string key, object partialData);
        Task<IEnumerable<string>> GetAllKeysAsync();
    }
}
