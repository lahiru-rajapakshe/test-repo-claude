using Google.Protobuf;
using Common.Infrastructure.Kafka.Producer;
using Common.Messaging;
using Common.Infrastructure.Localization;
using System.Globalization;

namespace Common.Infrastructure.Kafka.Consumer
{
    /// <summary>
    /// Abstract base class for Kafka message consumers that respond to messages.
    /// </summary>
    /// <typeparam name="TMessage">The type of the consumed message.</typeparam>
    /// <typeparam name="TResponse">The type of the response message.</typeparam>
    public abstract class ResponderMessageConsumer<TMessage, TResponse> : IKafkaMessageConsumer<TMessage>
        where TMessage : class, IMessage<TMessage>, new()
        where TResponse : class, IMessage<TResponse>, new()
    {
        private readonly IKafkaProducer<TResponse> _producer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponderMessageConsumer{TMessage, TResponse}"/> class.
        /// </summary>
        /// <param name="producer">The Kafka producer for sending response messages.</param>
        public ResponderMessageConsumer(IKafkaProducer<TResponse> producer)
        {
            _producer = producer;
        }
        
        /// <summary>
        /// Handles the response to a consumed message asynchronously.
        /// </summary>
        /// <param name="message">The consumed message to respond to.</param>
        /// <returns>A task representing the asynchronous operation and containing the response message.</returns>
        protected abstract Task<TResponse> RespondAsync(TMessage message);
        
        /// <inheritdoc />
        public async Task ConsumeAsync(KafkaMessage<TMessage> kafkaMessage)
        {
            if (!(kafkaMessage.Headers ?? new Dictionary<string, string>()).TryGetValue(
                    KnownHeaders.CorrelationIdHeaderName,
                    out var correlationId))
            {
                throw new InvalidOperationException($"No correlation id header found in message {kafkaMessage}");
            }

            // Extract language from headers
            var language = kafkaMessage.Headers.TryGetValue("language", out var lang) ? lang : "en-US";

            // Store original culture to restore after processing
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            var originalUICulture = Thread.CurrentThread.CurrentUICulture;


            try
            {
                // Set thread culture and update localization context
                var cultureInfo = new CultureInfo(language);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                KafkaLocalizationContext.SetLanguage(language);

                var response = await RespondAsync(kafkaMessage.Message);
            
            await _producer.ProduceAsync(
                new KafkaMessage<TResponse>(
                    response,
                    string.Empty,
                    new Dictionary<string, string>()
                    {
                        { KnownHeaders.CorrelationIdHeaderName, correlationId }
                    }));
            }
            finally
            {
                // Restore original culture after handling the message
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalUICulture;
                KafkaLocalizationContext.SetLanguage("en-US");
            }
        }
    }
}
