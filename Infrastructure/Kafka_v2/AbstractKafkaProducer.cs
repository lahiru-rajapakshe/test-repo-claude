using Common.Infrastructure.Configuration;
using Common.Infrastructure.Localization;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Kafka
{
    public abstract class AbstractKafkaProducer<TRequestEvent, TResponseEvent> : IDisposable
        where TRequestEvent : class
        where TResponseEvent : class
    {
        private readonly KafkaConfig _kafkaConfig;
        private readonly ILogger _logger;
        private readonly string _replyTopic;
        private IProducer<string, string>? _producer;
        private IConsumer<string, string>? _consumer;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<TResponseEvent>> _responseHandlers;
        private CancellationTokenSource? _cts;
        private Task? _consumerTask;
        private bool _disposed;

        protected AbstractKafkaProducer(KafkaConfig kafkaConfig, ILogger logger, string replyTopic)
        {
            _kafkaConfig = kafkaConfig;
            _logger = logger;
            _replyTopic = replyTopic;
            _responseHandlers = new ConcurrentDictionary<string, TaskCompletionSource<TResponseEvent>>();
            InitializeProducerAndConsumer();
        }

        private void InitializeProducerAndConsumer()
        {
            var groupId = _kafkaConfig.ServiceName ?? $"kafka-producer-{typeof(TRequestEvent).Name}";

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                SocketKeepaliveEnable = true,
                SocketTimeoutMs = 10000,
                MetadataMaxAgeMs = 10000, // Refresh metadata often
                MessageSendMaxRetries = 10,
                RetryBackoffMs = 1000,
                EnableIdempotence = true, // safer retries
                ReconnectBackoffMs = 500,
                ReconnectBackoffMaxMs = 30000

            };
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                SessionTimeoutMs = 30000, // Default is 10000 ms
                MaxPollIntervalMs = 300000, // Adjust if rebalancing takes longer
                MetadataMaxAgeMs = 10000,  // <- refresh metadata more often
                ReconnectBackoffMs = 500,
                ReconnectBackoffMaxMs = 10000,
                SocketKeepaliveEnable = true
                // Include security settings if necessary
            };

            _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
            _consumer.Subscribe(_replyTopic);

            _cts = new CancellationTokenSource();
            _consumerTask = Task.Run(() => ConsumeReplies(_cts.Token));
        }

        private void ConsumeReplies(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    var message = consumeResult.Message;
                    var headers = message.Headers;

                    var correlationId = headers.TryGetLastBytes("correlationId", out var correlationIdBytes)
                        ? Encoding.UTF8.GetString(correlationIdBytes)
                        : null;

                    if (correlationId != null && _responseHandlers.TryRemove(correlationId, out var tcs))
                    {
                        if (message.Value != null)
                        {
                            var responseEvent = JsonSerializer.Deserialize<TResponseEvent>(message.Value);
                            tcs.SetResult(responseEvent);
                        }
                        else
                        {
                            tcs.SetException(new InvalidOperationException("Received null response message."));
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("ConsumeReplies operation canceled.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ConsumeReplies.");
            }
            finally
            {
                _consumer.Close();
                _consumer.Dispose();
            }
        }

        public async Task<TResponseEvent> SendRequestAsync(string topic, TRequestEvent requestEvent, TimeSpan timeout)
        {
            var correlationId = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<TResponseEvent>();
            _responseHandlers[correlationId] = tcs;

            var eventJson = JsonSerializer.Serialize(requestEvent);
            var message = new Message<string, string>
            {
                Key = null,
                Value = eventJson,
                Headers = new Headers
                {
                    { "correlationId", Encoding.UTF8.GetBytes(correlationId) },
                    { "replyTopic", Encoding.UTF8.GetBytes(_replyTopic) },
                    { "eventType", Encoding.UTF8.GetBytes(typeof(TRequestEvent).Name) },
                    { "language", Encoding.UTF8.GetBytes(KafkaLocalizationContext.GetLanguage()) }
                }
            };

            try
            {
                await _producer.ProduceAsync(topic, message).ConfigureAwait(false);
                _logger.LogInformation("Event {EventType} produced to topic {Topic}", typeof(TRequestEvent).Name, topic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error producing event {EventType} to topic {Topic}", typeof(TRequestEvent).Name, topic);
                _responseHandlers.TryRemove(correlationId, out _);
                throw;
            }

            using var cts = new CancellationTokenSource(timeout);
            using (cts.Token.Register(() => tcs.TrySetCanceled()))
            {
                try
                {
                    var responseEvent = await tcs.Task.ConfigureAwait(false);
                    return responseEvent;
                }
                catch (TaskCanceledException)
                {
                    throw new TimeoutException("The request timed out.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during response processing.");
                    throw;
                }
                finally
                {
                    _responseHandlers.TryRemove(correlationId, out _);
                }
            }
        }

        public async Task FireAndForgetAsync(string topic, TRequestEvent eventMessage)
        {
            var eventJson = JsonSerializer.Serialize(eventMessage);
            var message = new Message<string, string>
            {
                Key = null,
                Value = eventJson,
                Headers = new Headers
                {
                    { "eventType", Encoding.UTF8.GetBytes(typeof(TRequestEvent).Name) },
                    { "language", Encoding.UTF8.GetBytes(KafkaLocalizationContext.GetLanguage()) }
                }
            };

            try
            {
                await _producer.ProduceAsync(topic, message).ConfigureAwait(false);
                _logger.LogInformation("Event {EventType} produced to topic {Topic}", typeof(TRequestEvent).Name, topic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error producing event {EventType} to topic {Topic}", typeof(TRequestEvent).Name, topic);
                throw;
            }
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
                catch (AggregateException ex) when (ex.InnerException is OperationCanceledException)
                {
                    // Expected exception during cancellation
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception during Dispose.");
                }

                _producer.Dispose();
                _cts.Dispose();
                _disposed = true;
            }
        }
    }
}
