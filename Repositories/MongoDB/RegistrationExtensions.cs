using Microsoft.Extensions.Options;
using Common.Infrastructure.Configuration;
using Common.Infrastructure.MongoDB;
using Common.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Repository.MongoDB
{
    /// <summary>
    /// Extension methods for registering MongoDB repositories.
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Adds a MongoDB repository for the specified entity to the specified <paramref name="services"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="services">The service collection to add services to.</param>
        /// <param name="collectionName">The name of the MongoDB collection.</param>
        public static void AddMongoDBRepository<TEntity>(this IServiceCollection services, string collectionName) where TEntity : BaseMongoEntity
        {
            services.AddTransient<IGenericRepository<TEntity, string>>(sp => new GenericMongoDBRepository<TEntity>(
                sp.GetRequiredService<IMongoDbClientProvider>(),
                sp.GetRequiredService<IServiceProvider>(),
                sp.GetRequiredService<IOptions<MongoConfig>>().Value.DatabaseName,
                collectionName));
        }
    }
}