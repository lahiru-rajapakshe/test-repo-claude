using System.Collections.Concurrent;
using Google.Protobuf;
using Common.Infrastructure.Kafka.MessageNotifier;
using Common.Infrastructure.Kafka.Producer;
using Common.Messaging;
using Microsoft.Extensions.Logging;
using Common.Infrastructure.Localization;

namespace Common.Infrastructure.Kafka.RequestSender
{
    /// <summary>
    /// Implementation of <see cref="IKafkaRequestSender{TRequestMessage, TResponseMessage}"/> for sending requests to Kafka.
    /// </summary>
    /// <typeparam name="TRequestMessage">The type of the request message.</typeparam>
    /// <typeparam name="TResponseMessage">The type of the response message.</typeparam>
    public class
        KafkaRequestSender<TRequestMessage, TResponseMessage> : IKafkaRequestSender<TRequestMessage, TResponseMessage>
        where TRequestMessage : class, IMessage<TRequestMessage>, new()
        where TResponseMessage : class, IMessage<TResponseMessage>, new()
    {
        private readonly IKafkaProducer<TRequestMessage> _kafkaProducer;
        private readonly ILogger<KafkaRequestSender<TRequestMessage, TResponseMessage>> _logger;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<TResponseMessage>> _pendingRequests = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="KafkaRequestSender{TRequestMessage, TResponseMessage}"/> class.
        /// </summary>
        /// <param name="kafkaMessageNotifier">The Kafka message notifier for handling response messages.</param>
        /// <param name="kafkaProducer">The Kafka producer for sending request messages.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public KafkaRequestSender(
            IKafkaMessageNotifier<TResponseMessage> kafkaMessageNotifier,
            IKafkaProducer<TRequestMessage> kafkaProducer,
            ILogger<KafkaRequestSender<TRequestMessage, TResponseMessage>> logger)
        {
            _kafkaProducer = kafkaProducer;
            _logger = logger;

            kafkaMessageNotifier.Subscribe(OnMessageReceivedAsync);
        }

        private Task OnMessageReceivedAsync(KafkaMessage<TResponseMessage> message)
        {
            if ((message.Headers ?? new Dictionary<string, string>()).TryGetValue(
                    KnownHeaders.CorrelationIdHeaderName,
                    out var correlationId))
            {
                if (_pendingRequests.TryRemove(correlationId, out var taskCompletionSource))
                {
                    taskCompletionSource.SetResult(message.Message);
                }
                else
                {
                    _logger.LogWarning($"No pending request found for correlation id {correlationId}");
                }
            }
            else
            {
                _logger.LogWarning($"No correlation id header found in message {message}");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Sends a request message to Kafka and asynchronously waits for a response.
        /// </summary>
        /// <param name="message">The request message to be sent.</param>
        /// <param name="messageKey">The key associated with the message for routing purposes.</param>x`
        /// <returns>A task representing the asynchronous operation and containing the response message.</returns>
        public async Task<TResponseMessage> SendAsync(TRequestMessage message, string messageKey)
        {
            var correlationId = Guid.NewGuid().ToString();

            var headers = new Dictionary<string, string>
            {
                { KnownHeaders.CorrelationIdHeaderName, correlationId },
                {Constants.Language, KafkaLocalizationContext.GetLanguage()}
            };         

            await _kafkaProducer.ProduceAsync(
                new KafkaMessage<TRequestMessage>(
                    message,
                    messageKey,
                    headers
                ));

            var taskCompletionSource = new TaskCompletionSource<TResponseMessage>();
            _pendingRequests.TryAdd(correlationId, taskCompletionSource);

            var timeout = TimeSpan.FromSeconds(120);
            var cts = new CancellationTokenSource(timeout);
            var completedTask = await Task.WhenAny(taskCompletionSource.Task, Task.Delay(Timeout.Infinite, cts.Token));
            if (completedTask == taskCompletionSource.Task)
            {
                cts.Cancel(); // Cancel the timeout
                return await taskCompletionSource.Task;
            }

            _pendingRequests.TryRemove(correlationId, out _);
            throw new TimeoutException($"Request timed out after {timeout.TotalSeconds} seconds");
        }
    }
}