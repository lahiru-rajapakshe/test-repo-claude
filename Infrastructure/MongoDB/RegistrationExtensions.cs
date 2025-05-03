using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.MongoDB
{
    public static class RegistrationExtensions
    {
        public static void AddMongoDBClient(this IServiceCollection services) => 
            services.AddSingleton<IMongoDbClientProvider, MongoDBClientProvider>();
    }
}
