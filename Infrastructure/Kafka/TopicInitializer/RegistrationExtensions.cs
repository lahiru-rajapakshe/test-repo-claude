using Microsoft.Extensions.Options;
using Common.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Kafka.TopicInitializer
{
    /// <summary>
    /// Extension methods for registering Kafka Topic Initializer services.
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Adds Kafka Topic Initializer services to the specified <paramref name="services"/>.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        /// <param name="topics">The list of Kafka topics to initialize.</param>
        public static void AddTopicInitializer(
            this IServiceCollection services,
            IEnumerable<string> topics)
        {
            services.AddHostedService<TopicInitializerHostedService>();

            services.AddTransient<ITopicInitializer>(sp =>
                new TopicInitializer(
                    topics,
                    sp.GetRequiredService<IOptions<KafkaConfig>>(),
                    sp.GetRequiredService<ILogger<TopicInitializer>>()));
        }
    }
}