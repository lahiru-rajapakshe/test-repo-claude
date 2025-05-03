using Common.Infrastructure.Configuration;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Infrastructure.Kafka_v3
{
    public class TopicManagerV3
    {
        private readonly KafkaConfig _kafkaSettings;
        private readonly ILogger<TopicManagerV3> _logger;

        public TopicManagerV3(KafkaConfig kafkaSettings, ILogger<TopicManagerV3> logger)
        {
            _kafkaSettings = kafkaSettings;
            _logger = logger;
        }

        public async Task CreateTopicsAsync(IEnumerable<string> topicNames, int numPartitions = 10, short replicationFactor = 1)
        {
            var adminConfig = new AdminClientConfig { BootstrapServers = _kafkaSettings.BootstrapServers };

            using (var adminClient = new AdminClientBuilder(adminConfig).Build())
            {
                var topicSpecifications = new List<TopicSpecification>();
                foreach (var topicName in topicNames)
                {
                    topicSpecifications.Add(new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = numPartitions,
                        ReplicationFactor = replicationFactor
                    });
                }

                try
                {
                    await adminClient.CreateTopicsAsync(topicSpecifications);
                    _logger.LogInformation("Topics created successfully: {Topics} with {Partitions} partitions and {Replication} replication factor.",
                        string.Join(", ", topicNames), numPartitions, replicationFactor);
                }
                catch (CreateTopicsException e)
                {
                    foreach (var result in e.Results)
                    {
                        if (result.Error.Code == ErrorCode.TopicAlreadyExists)
                        {
                            _logger.LogInformation("Topic {Topic} already exists.", result.Topic);
                        }
                        else
                        {
                            _logger.LogError("An error occurred creating topic {Topic}: {Reason}", result.Topic, result.Error.Reason);
                            throw;
                        }
                    }
                }
            }
        }
    }
}