using Confluent.Kafka;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Consumer
{
    public abstract partial class AbstractKafkaConsumerV3<TRequestEvent, TResponseEvent>
    {
        protected virtual ConsumerConfig DefaultCreateConsumerConfig()
        {
            return new ConsumerConfig
            {
                BootstrapServers = _kafkaSettings.BootstrapServers,
                GroupId = $"{_kafkaSettings.ServiceName ?? _requestTopic}-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false, // Crucial for exactly-once
                SessionTimeoutMs = 30000,
                MaxPollIntervalMs = 300000,
                ReconnectBackoffMs = 100,
                ReconnectBackoffMaxMs = 10000,
                IsolationLevel = IsolationLevel.ReadCommitted // Read only committed transactional messages
                // Security settings if necessary
            };
        }
    }
}