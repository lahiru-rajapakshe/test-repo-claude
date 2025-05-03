using Common.Infrastructure.Configuration;
using Confluent.Kafka; // Ensure this is present
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Producer
{
    public abstract partial class AbstractKafkaProducerV3<TRequestEvent, TResponseEvent> : IDisposable
        where TRequestEvent : class
        where TResponseEvent : class
    {
        protected readonly KafkaConfig _kafkaConfig;
        protected readonly ILogger _logger;
        protected readonly string _replyTopic;
        protected IProducer<string, string>? _producer;
        protected IConsumer<string, string>? _consumer;
        protected readonly ConcurrentDictionary<string, TaskCompletionSource<TResponseEvent>> _responseHandlers;
        protected CancellationTokenSource? _cts;
        protected Task? _consumerTask;
        private bool _disposed;
        protected readonly string _transactionalId;

        protected AbstractKafkaProducerV3(KafkaConfig kafkaConfig, ILogger logger, string replyTopic)
        {
            _kafkaConfig = kafkaConfig;
            _logger = logger;
            _replyTopic = replyTopic;
            _responseHandlers = new ConcurrentDictionary<string, TaskCompletionSource<TResponseEvent>>();
            _transactionalId = $"{_kafkaConfig.ServiceName ?? typeof(TRequestEvent).Name}-producer-{Guid.NewGuid().ToString()}";
            InitializeProducerAndConsumer();
        }

        protected abstract void InitializeProducerAndConsumer();
        protected abstract void ConsumeReplies(CancellationToken cancellationToken);
        public abstract Task FireAndForgetAsync(string topic, string? key, TRequestEvent eventMessage);

        public Task<TResponseEvent> SendRequestAsync(string topic, TRequestEvent requestEvent, TimeSpan timeout)
        {
            return SendRequestAsync(topic, null, requestEvent, timeout);
        }
        public async Task<TResponseEvent> SendRequestAsync(string topic, string? key, TRequestEvent requestEvent, TimeSpan timeout)
        {
            if (_producer == null)
                throw new InvalidOperationException("Kafka producer is not initialized.");

            if (_consumer == null)
                throw new InvalidOperationException("Kafka consumer is not initialized.");

            if (string.IsNullOrEmpty(_replyTopic))
                throw new InvalidOperationException("Reply topic is not configured.");

            var correlationId = Guid.NewGuid().ToString();

            var tcs = new TaskCompletionSource<TResponseEvent>(TaskCreationOptions.RunContinuationsAsynchronously);
            _responseHandlers[correlationId] = tcs;

            var headers = new Headers
            {
                { "correlation-id", System.Text.Encoding.UTF8.GetBytes(correlationId) },
                { "reply-topic", System.Text.Encoding.UTF8.GetBytes(_replyTopic) }
            };

            var serializedValue = SerializeRequest(requestEvent);

            var message = new Message<string, string>
            {
                Key = key ?? Guid.NewGuid().ToString(), // Ensures message is hashed to a partition
                Value = serializedValue,
                Headers = headers
            };

            try
            {
                await _producer.ProduceAsync(topic, message);
                _logger.LogInformation("Produced message with CorrelationId={CorrelationId}, Topic={Topic}, Key={Key}", correlationId, topic, message.Key);
            }
            catch (ProduceException<string, string> ex)
            {
                _logger.LogError(ex, "Error producing Kafka message with key={Key}", message.Key);
                _responseHandlers.TryRemove(correlationId, out _);
                throw;
            }

            using var timeoutCts = new CancellationTokenSource(timeout);
            using (timeoutCts.Token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false))
            {
                try
                {
                    return await tcs.Task;
                }
                finally
                {
                    _responseHandlers.TryRemove(correlationId, out _);
                }
            }
        }

        protected virtual string SerializeRequest(TRequestEvent request)
        {
            return System.Text.Json.JsonSerializer.Serialize(request);
        }

        public Task FireAndForgetAsync(string topic, TRequestEvent eventMessage)
        {
            return FireAndForgetAsync(topic, null, eventMessage);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _cts?.Cancel();

                try
                {
                    _consumerTask?.Wait();
                }
                catch (AggregateException ex) when (ex.InnerException is OperationCanceledException) { /* Expected */ }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception during Dispose.");
                }

                _producer?.Dispose();
                _consumer?.Dispose();
                _cts?.Dispose();
                _disposed = true;
            }
        }
    }
}