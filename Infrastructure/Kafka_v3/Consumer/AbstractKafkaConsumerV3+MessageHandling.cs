using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Consumer
{
    public abstract partial class AbstractKafkaConsumerV3<TRequestEvent, TResponseEvent>
    {
        protected virtual string DefaultExtractLanguageHeader(Headers headers)
        {
            if (headers.TryGetLastBytes("language", out var languageBytes))
            {
                var language = Encoding.UTF8.GetString(languageBytes);
                _logger.LogDebug("Language header found: {Language}", language);
                return language;
            }
            return "en-US"; // Default language
        }

        protected virtual TRequestEvent? DefaultDeserializeMessage(string messageValue)
        {
            if (messageValue == null)
            {
                _logger.LogWarning("Received null message on topic {Topic}. Skipping.", _requestTopic);
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<TRequestEvent>(messageValue);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize message on topic {Topic}: {Value}. Skipping.", _requestTopic, messageValue);
                return null;
            }
        }

        protected virtual void DefaultSetCurrentCulture(string language)
        {
            try
            {
                var cultureInfo = new CultureInfo(language);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Localization.KafkaLocalizationContext.SetLanguage(language);
            }
            catch (CultureNotFoundException ex)
            {
                _logger.LogWarning(ex, "Culture '{Language}' not found. Using default 'en-US'.", language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Localization.KafkaLocalizationContext.SetLanguage("en-US");
            }
        }

        protected virtual void DefaultRestoreCulture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;
            Localization.KafkaLocalizationContext.SetLanguage("en-US");
        }
    }
}