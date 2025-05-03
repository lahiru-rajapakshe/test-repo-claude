using Common.Infrastructure.Configuration;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Consumer
{
    public abstract partial class AbstractKafkaConsumerV3<TRequestEvent, TResponseEvent> : IDisposable
        where TRequestEvent : class
        where TResponseEvent : class
    {
        protected readonly IConsumer<string, string> _consumer;
        protected readonly IProducer<string, string>? _producer;
        protected readonly KafkaConfig _kafkaSettings;
        protected readonly ILogger _logger;
        protected readonly string _requestTopic;
        protected readonly string _replyTopic;
        private readonly CancellationTokenSource _cts;
        private readonly Task _consumerTask;
        private bool _disposed = false;

        protected AbstractKafkaConsumerV3(
            KafkaConfig kafkaSettings,
            ILogger logger,
            string requestTopic,
            string? replyTopic = null)
        {
            _kafkaSettings = kafkaSettings ?? throw new ArgumentNullException(nameof(kafkaSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _requestTopic = requestTopic ?? throw new ArgumentNullException(nameof(requestTopic));
            _replyTopic = replyTopic ?? string.Empty;

            var consumerConfig = CreateConsumerConfig();
            _consumer = new ConsumerBuilder<string, string>(consumerConfig)
                .SetErrorHandler((_, e) => _logger.LogError("Consumer Error: {Reason}", e.Reason))
                .SetPartitionsAssignedHandler(OnPartitionsAssigned)
                .SetPartitionsRevokedHandler(OnPartitionsRevoked)
                .Build();

            _consumer.Subscribe(_requestTopic);

            if (!string.IsNullOrEmpty(_replyTopic))
            {
                _producer = CreateProducer();
            }

            _cts = new CancellationTokenSource();
            _consumerTask = Task.Run(() => ConsumeLoop(_cts.Token)); // Call the ConsumeLoop from the partial class
        }

        protected abstract ConsumerConfig CreateConsumerConfig();
        protected virtual IProducer<string, string>? CreateProducer()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = _kafkaSettings.BootstrapServers };
            return new ProducerBuilder<string, string>(producerConfig).Build();
        }

        protected abstract Task<TResponseEvent?> HandleMessageAsync(TRequestEvent message);
        protected abstract string ExtractLanguageHeader(Headers headers);
        protected abstract TRequestEvent? DeserializeMessage(string messageValue);
        protected abstract void SetCurrentCulture(string language);
        protected abstract void RestoreCulture();
        protected abstract Task SendReplyAsync(TResponseEvent responseEvent, Headers requestHeaders);

        protected virtual void OnPartitionsAssigned(IConsumer<string, string> c,List<Confluent.Kafka.TopicPartition> assignments)
        {
            _logger.LogInformation("Assigned partitions: [{Partitions}]", string.Join(", ", assignments));
        }

        protected virtual void OnPartitionsRevoked(IConsumer<string, string> c, List<Confluent.Kafka.TopicPartitionOffset> partitions)
        {
            _logger.LogInformation("Revoked partitions: [{Partitions}]", string.Join(", ", partitions));
            // Optionally commit current offsets synchronously here if needed
        }

        private void Cleanup()
        {
            _consumer.Close();
            _consumer.Dispose();
            _producer?.Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _cts.Cancel();
                try
                {
                    _consumerTask.Wait();
                }
                catch (AggregateException ex) when (ex.InnerException is OperationCanceledException) { /* Expected */ }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during disposal of consumer for topic {Topic}.", _requestTopic);
                }
                finally
                {
                    Cleanup();
                    _cts.Dispose();
                    _disposed = true;
                }
            }
        }
    }
}