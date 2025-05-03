using Confluent.Kafka;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Producer
{
    public abstract partial class AbstractKafkaProducerV3<TRequestEvent, TResponseEvent>
    {
        protected virtual void DefaultInitializeProducerAndConsumer()
        {
            var groupId = _kafkaConfig.ServiceName ?? $"kafka-producer-{typeof(TRequestEvent).Name}";

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                SocketKeepaliveEnable = true,
                SocketTimeoutMs = 10000,
                MetadataMaxAgeMs = 10000,
                MessageSendMaxRetries = 3,
                RetryBackoffMs = 1000,
                EnableIdempotence = true,
                ReconnectBackoffMs = 500,
                ReconnectBackoffMaxMs = 30000,
                Acks = Acks.All,
                TransactionalId = _transactionalId // Enable transactions
            };
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();
            _producer.InitTransactions(TimeSpan.FromSeconds(10));

            if (!string.IsNullOrEmpty(_replyTopic))
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = _kafkaConfig.BootstrapServers,
                    GroupId = groupId,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    EnableAutoCommit = true,
                    SessionTimeoutMs = 30000,
                    MaxPollIntervalMs = 300000,
                    MetadataMaxAgeMs = 10000,
                    ReconnectBackoffMs = 500,
                    ReconnectBackoffMaxMs = 10000,
                    SocketKeepaliveEnable = true
                };

                _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
                _consumer.Subscribe(_replyTopic);

                _cts = new CancellationTokenSource();
                _consumerTask = Task.Run(() => ConsumeReplies(_cts.Token));
            }
        }
    }
}