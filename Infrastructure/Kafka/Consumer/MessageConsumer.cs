using Common.Infrastructure.Kafka.Consumer;
using Common.Infrastructure.Localization;
using Common.Messaging;
using Google.Protobuf;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace DataImport.Consumer.Consumers
{
    public abstract class BaseMessageConsumer<TMessage> : IKafkaMessageConsumer<TMessage>
         where TMessage : class, IMessage<TMessage>, new()
    {
        protected readonly ILogger<BaseMessageConsumer<TMessage>> _logger;

        protected BaseMessageConsumer(ILogger<BaseMessageConsumer<TMessage>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ConsumeAsync(KafkaMessage<TMessage> kafkaMessage)
        {
            try
            {
                if (kafkaMessage.Message == null)
                {
                    _logger.LogError("Received a null message.");
                    return;
                }

                // Extract language header (default to en-US)
                var headers = kafkaMessage.Headers ?? new Dictionary<string, string>();
                var language = headers.TryGetValue("language", out var lang) ? lang : "en-US";

                _logger.LogDebug("Using language: {Language}", language);

                // Store original culture
                var originalCulture = Thread.CurrentThread.CurrentCulture;
                var originalUICulture = Thread.CurrentThread.CurrentUICulture;

                try
                {
                    var cultureInfo = new CultureInfo(language);

                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;

                    KafkaLocalizationContext.SetLanguage(language); // if used globally

                    await ProcessMessageAsync(kafkaMessage.Message);
                }
                finally
                {
                    // Always reset culture after processing
                    Thread.CurrentThread.CurrentCulture = originalCulture;
                    Thread.CurrentThread.CurrentUICulture = originalUICulture;

                    KafkaLocalizationContext.SetLanguage("en-US"); // reset default
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message.");
            }
        }

        /// <summary>
        /// When implemented in a derived class, processes the message.
        /// </summary>
        /// <param name="message">The message to process.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected abstract Task ProcessMessageAsync(TMessage message);
    }
}
