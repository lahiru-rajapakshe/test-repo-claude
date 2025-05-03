using Common.Infrastructure.Localization;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Producer
{
    public abstract partial class AbstractKafkaProducerV3<TRequestEvent, TResponseEvent>
    {
        public virtual async Task<TResponseEvent> DefaultSendRequestAsync(string topic, string? key, TRequestEvent requestEvent, TimeSpan timeout)
        {
            var correlationId = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<TResponseEvent>();
            _responseHandlers[correlationId] = tcs;

            var eventJson = JsonSerializer.Serialize(requestEvent);
            var message = new Message<string, string>
            {
                Key = key,
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
                _producer?.BeginTransaction(); // Null-conditional operator
                await _producer.ProduceAsync(topic, message).ConfigureAwait(false);
                _producer?.CommitTransaction(); // Use synchronous CommitTransaction here
                _logger.LogInformation("Transactional event {EventType} produced to topic {Topic} with key {Key}",
                    typeof(TRequestEvent).Name, topic, key ?? "null (round-robin)");
            }
            catch (ProduceException<string, string> ex)
            {
                _logger.LogError(ex, "Error producing transactional event {EventType} to topic {Topic} with key {Key}. Aborting transaction.",
                    typeof(TRequestEvent).Name, topic, key);
                _producer?.AbortTransaction(); // Use synchronous AbortTransaction here
                _responseHandlers.TryRemove(correlationId, out _);
                throw;
            }
            catch (KafkaException ex)
            {
                _logger.LogError(ex, "Kafka error during transactional production of {EventType} to {Topic}. Aborting transaction.",
                    typeof(TRequestEvent).Name, topic);
                _producer?.AbortTransaction(); // Use synchronous AbortTransaction here
                _responseHandlers.TryRemove(correlationId, out _);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "General error during transactional production of {EventType} to {Topic}. Aborting transaction.",
                    typeof(TRequestEvent).Name, topic);
                _producer?.AbortTransaction(); // Use synchronous AbortTransaction here
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
    }
}
