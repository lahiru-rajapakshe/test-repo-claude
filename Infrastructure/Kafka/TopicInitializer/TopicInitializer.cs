using Confluent.Kafka.Admin;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Common.Infrastructure.Configuration;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Kafka.TopicInitializer
{
    /// <summary>
    /// Interface for initializing Kafka topics.
    /// </summary>
    public interface ITopicInitializer
    {
        /// <summary>
        /// Initializes Kafka topics.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task InitializeAsync();
    }

    /// <summary>
    /// Implementation of <see cref="ITopicInitializer"/> for initializing Kafka topics.
    /// </summary>
    public class TopicInitializer : ITopicInitializer
    {
        private readonly IEnumerable<string> _topics;
        private readonly ILogger<TopicInitializer> _logger;
        private KafkaConfig _kafkaConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicInitializer"/> class.
        /// </summary>
        /// <param name="topics">The list of Kafka topics to be initialized.</param>
        /// <param name="kafkaConfig">The Kafka configuration options.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public TopicInitializer(
            IEnumerable<string> topics,
            IOptions<KafkaConfig> kafkaConfig, ILogger<TopicInitializer> logger)
        {
            _kafkaConfig = kafkaConfig.Value;
            _topics = topics;
            _logger = logger;
        }

        /// <summary>
        /// Initializes Kafka topics asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InitializeAsync()
        {
            var config = new AdminClientConfig { BootstrapServers = _kafkaConfig.BootstrapServers, Debug = "all" };

            using var adminClient = new AdminClientBuilder(config)
                .SetErrorHandler((_, msg) => _logger.LogError(msg.Reason))
                .SetLogHandler((_, msg) => _logger.LogInformation(msg.Message)).Build();

            var meta = adminClient.GetMetadata(TimeSpan.FromSeconds(20));
            _logger.LogInformation($"Connected to {meta.OriginatingBrokerId} at {meta.OriginatingBrokerName}");

            foreach (var topic in _topics)
            {
                var topicSpecification = new TopicSpecification
                {
                    Name = topic,
                    NumPartitions = 1,
                    ReplicationFactor = 1
                };

                try
                {
                    await adminClient.CreateTopicsAsync(new List<TopicSpecification> { topicSpecification });
                    _logger.LogInformation($"Topic {topicSpecification.Name} created successfully.");
                }
                catch (Exception e)
                {
                    _logger.LogError($"An error occurred creating topic: {e.Message}");
                }
            }
        }
    }
}