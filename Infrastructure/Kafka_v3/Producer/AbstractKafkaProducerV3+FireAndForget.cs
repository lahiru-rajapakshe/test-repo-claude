using Common.Infrastructure.Localization;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Producer
{
    public abstract partial class AbstractKafkaProducerV3<TRequestEvent, TResponseEvent>
    {
        public virtual async Task DefaultFireAndForgetAsync(string topic, string? key, TRequestEvent eventMessage)
        {
            if (_producer == null)
                throw new InvalidOperationException("Kafka producer is not initialized.");

            var eventJson = JsonSerializer.Serialize(eventMessage);
            var message = new Message<string, string>
            {
                Key = key,
                Value = eventJson,
                Headers = new Headers
        {
            { "eventType", Encoding.UTF8.GetBytes(typeof(TRequestEvent).Name) },
            { "language", Encoding.UTF8.GetBytes(KafkaLocalizationContext.GetLanguage()) }
        }
            };

            try
            {
                _producer.BeginTransaction();
                await _producer.ProduceAsync(topic, message).ConfigureAwait(false);
                _producer.CommitTransaction();

                _logger.LogInformation("Transactional event {EventType} produced to topic {Topic} with key {Key}",
                    typeof(TRequestEvent).Name, topic, key ?? "null (round-robin)");
            }
            catch (ProduceException<string, string> ex)
            {
                _logger.LogError(ex, "Error producing transactional event {EventType} to topic {Topic} with key {Key}. Aborting transaction.",
                    typeof(TRequestEvent).Name, topic, key);
                _producer.AbortTransaction();
                throw;
            }
            catch (KafkaException ex)
            {
                _logger.LogError(ex, "Kafka error during transactional production of {EventType} to {Topic}. Aborting transaction.",
                    typeof(TRequestEvent).Name, topic);
                _producer.AbortTransaction();
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "General error during transactional production of {EventType} to {Topic}. Aborting transaction.",
                    typeof(TRequestEvent).Name, topic);
                _producer.AbortTransaction();
                throw;
            }
        }

    }
}