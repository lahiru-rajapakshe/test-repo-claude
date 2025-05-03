using Polly;

using System.Text;
using System.Globalization;

using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry.Serdes;

using Google.Protobuf;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

using Common.Messaging;
using Common.RequestContext;
using Common.Infrastructure.Configuration;

using static Common.Infrastructure.Constants;

namespace Common.Infrastructure.Kafka.Consumer
{
    /// <summary>
    /// Hosted service for consuming Kafka messages of type <typeparamref name="TMessage"/>.
    /// </summary>
    /// <typeparam name="TMessage">The type of Kafka message to consume.</typeparam>
    public class KafkaConsumerHostedService<TMessage> : BackgroundService
        where TMessage : class, IMessage<TMessage>, new()
    {
        /// <summary>
        /// The Kafka configuration options.
        /// </summary>
        private readonly KafkaConfig _kafkaConfig;

        /// <summary>
        /// The Kafka topic to consume messages from.
        /// </summary>
        private readonly string _topic;

        /// <summary>
        /// The Kafka consumer group to which this consumer belongs.
        /// </summary>
        private readonly string _consumerGroup;

        /// <summary>
        /// The factory for creating service scopes.
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// The logger for logging messages.
        /// </summary>
        private readonly ILogger<KafkaConsumerHostedService<TMessage>> _logger;

        /// <summary>
        /// The background thread for consuming Kafka messages.
        /// </summary>
        private Thread? _thread;

        /// <summary>
        /// Flag indicating whether the consumer is disposed.
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Task completion source for asynchronous operations.
        /// </summary>
        private TaskCompletionSource<object?>? _taskCompletionSource;

        /// <summary>
        /// Cancellation token source for stopping the consumer.
        /// </summary>
        private CancellationTokenSource? _cancellationTokenSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaConsumerHostedService{TMessage}"/> class.
        /// </summary>
        /// <param name="topic">The Kafka topic to consume messages from.</param>
        /// <param name="consumerGroup">The Kafka consumer group to which this consumer belongs.</param>
        /// <param name="kafkaConfig">The Kafka configuration options.</param>
        /// <param name="serviceScopeFactory">The factory for creating service scopes.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public KafkaConsumerHostedService(
            string topic,
            string consumerGroup,
            IOptions<KafkaConfig> kafkaConfig,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<KafkaConsumerHostedService<TMessage>> logger)
        {
            _kafkaConfig = kafkaConfig.Value;
            _topic = topic;
            _consumerGroup = consumerGroup;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }


        /// <summary>
        /// Starts the Kafka consumer thread asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        #pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        private Task StartAsync(CancellationToken cancellationToken)
        #pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(KafkaConsumerHostedService<TMessage>),
                    $"Consumer is disposed");
            }

            if (_thread != null)
            {
                throw new InvalidOperationException($"Consumer is already started..");
            }

            _thread = new Thread(ThreadEntryPoint)
            {
                IsBackground = true,
                Priority = ThreadPriority.Normal,
                CurrentCulture = CultureInfo.InvariantCulture,
                CurrentUICulture = CultureInfo.InvariantCulture,
                Name = $"{nameof(KafkaConsumerHostedService<TMessage>)}_{Guid.NewGuid():n}",
            };

            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _taskCompletionSource =
                new TaskCompletionSource<object?>(TaskCreationOptions.RunContinuationsAsynchronously);
            _thread.Start();
            return _taskCompletionSource.Task;
        }

        /// <summary>
        /// Entry point for the Kafka consumer thread.
        /// </summary>
        private void ThreadEntryPoint()
        {
            var cancellationToken = _cancellationTokenSource?.Token
                                    ?? throw new NullReferenceException("Unexpected null in CancellationTokenSource");
            try
            {
                Policy
                    .Handle<Exception>()
                    .WaitAndRetry(
                        5, // Retry up to 5 times
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // Exponential backoff
                        (exception, timeSpan, retryCount, context) =>
                        {
                            _logger.LogWarning($"Retry {retryCount} failed: {exception.Message}");
                        })
                    .Execute(() => StartConsuming(cancellationToken));

                _taskCompletionSource?.TrySetCanceled();
            }
            catch (OperationCanceledException)
            {
                _taskCompletionSource?.TrySetCanceled();
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"The consumer thread threw an exception: '{e.Message}'.",
                    e);
                _taskCompletionSource?.TrySetException(e);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
                _taskCompletionSource = null;
                _thread = null;

                _logger.LogInformation(
                    "The consumer thread is stopped.");
            }
        }

        /// <summary>
        /// Starts consuming Kafka messages.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        private void StartConsuming(CancellationToken cancellationToken)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = _consumerGroup,
                BootstrapServers = _kafkaConfig.BootstrapServers,
                EnableAutoCommit = false,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                MaxPollIntervalMs = 86400000, // Increase to 24 hours (86400000 ms),
                FetchMaxBytes = 10485760 // 10 MB, adjust as needed
            };

            IConsumer<string, TMessage>? consumer = null!;

            try
            {
                consumer =
                    new ConsumerBuilder<string, TMessage>(consumerConfig)
                        .SetValueDeserializer(new ProtobufDeserializer<TMessage>().AsSyncOverAsync())
                        .SetErrorHandler((_, e) => _logger.LogError($"Error: {e.Reason}"))
                        .SetLogHandler((_, msg) => _logger.LogInformation(msg.Message))
                        .Build();

                consumer.Subscribe(_topic);

                _logger.LogInformation($"Starting consumer for topic '{_topic}'.");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        _logger.LogInformation($"Consumer waiting for message topic {_topic}.");
                        var consumeResult = consumer.Consume(cancellationToken);
                        _logger.LogInformation(
                            $"Consume result '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");
                        var typedMessage = new TMessage();
                        if (consumeResult.Message.Value != null)
                        {
                            typedMessage = consumeResult.Message.Value;
                        }

                        using var scope = _serviceScopeFactory.CreateScope();

                        var typedMessageConsumer =
                            scope.ServiceProvider.GetRequiredService<IKafkaMessageConsumer<TMessage>>();

                        var requestContext = scope.ServiceProvider.GetService<IMutableRequestContext>();

                        var loggerState = new Dictionary<string, object>();

                        if (requestContext != null &&
                            consumeResult.Message.Headers.TryGetLastBytes(RequestIdHeaderName, out var requestId))
                        {
                            requestContext.RequestId = Encoding.UTF8.GetString(requestId);
                            loggerState.Add(RequestIdLogKey, requestContext.RequestId);
                        }

                        if (requestContext != null &&
                            consumeResult.Message.Headers.TryGetLastBytes(TenantIdHeaderName, out var tenantId))
                        {
                            requestContext.TenantId = Encoding.UTF8.GetString(tenantId);
                            loggerState.Add(TenantIdLogKey, requestContext.RequestId);
                        }

                        if (requestContext != null &&
                            consumeResult.Message.Headers.TryGetLastBytes(UserIdHeaderName, out var userId))
                        {
                            requestContext.UserId = Encoding.UTF8.GetString(userId);
                            loggerState.Add(UserIdLogKey, requestContext.RequestId);
                        }

                        if (requestContext != null &&
                            consumeResult.Message.Headers.TryGetLastBytes(AccessTokenHeaderName, out var accessToken))
                        {
                            requestContext.AccessToken = Encoding.UTF8.GetString(accessToken);
                        }

                        using (_logger.BeginScope(loggerState))
                        {
                            typedMessageConsumer.ConsumeAsync(new KafkaMessage<TMessage>(
                                typedMessage,
                                consumeResult.Message.Key,
                                consumeResult.Message.Headers
                                .Reverse() 
                                .GroupBy(x => x.Key)
                                .ToDictionary(
                                    g => g.Key,
                                    g => Encoding.UTF8.GetString(g.First().GetValueBytes())))

                            ).GetAwaiter().GetResult();

                            consumer.Commit(consumeResult);

                            _logger.LogInformation(
                                $"Committed message offset'{consumeResult.Message.Key}' from '{consumeResult.TopicPartitionOffset}'");
                        }
                    }
                    catch (ConsumeException e)
                    {
                        _logger.LogError($"Consume exception: {e.Message}");

                        // https://github.com/confluentinc/confluent-kafka-dotnet/issues/1366
                        if (e.Error.Code == ErrorCode.UnknownTopicOrPart)
                        {
                            continue;
                        }

                        if (e.Error.IsFatal)
                        {
                            throw;
                        }
                    }
                }

                _logger.LogInformation($"Consumer finished for topic '{_topic}'.");
            }
            catch (OperationCanceledException operationCanceledException)
            {
                _logger.LogError(operationCanceledException.Message, $"Consumer fatal error");
                consumer?.Close();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Consumer fatal error");
                throw;
            }
            finally
            {
                try
                {
                    consumer?.Close();
                }
                catch (ObjectDisposedException)
                {
                    // Handle the case where consumer is already disposed of.
                }
            }
        }

        /// <inheritdoc />
        protected override Task ExecuteAsync(CancellationToken stoppingToken) =>
            StartAsync(stoppingToken);

        /// <inheritdoc />
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            StopThread();
            if (disposing)
            {
                _taskCompletionSource?.TrySetResult(null);
                _cancellationTokenSource?.Dispose();
            }
            _cancellationTokenSource = null;
            _thread = null;
            _taskCompletionSource = null;
            _isDisposed = true;
        }

        /// <summary>
        /// Stops the Kafka consumer thread.
        /// </summary>
        private void StopThread()
        {
            var cts = _cancellationTokenSource;
            var thread = _thread;
            if (cts != null && !cts.IsCancellationRequested)
            {
                cts.Cancel();
            }
            if (thread != null && !thread.Join(10_000))
            {
                throw new ThreadStateException("Thread wasn't aborted, timeout is reached.");
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
