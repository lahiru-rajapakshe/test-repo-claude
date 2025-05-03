using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Consumer
{
    public abstract partial class AbstractKafkaConsumerV3<TRequestEvent, TResponseEvent>
    {
        protected virtual async Task DefaultSendReplyAsync(TResponseEvent responseEvent, Headers requestHeaders)
        {
            if (_producer == null || string.IsNullOrEmpty(_replyTopic))
            {
                _logger.LogError("Reply producer not initialized or reply topic not configured.");
                return;
            }

            if (!requestHeaders.TryGetLastBytes("correlationId", out var correlationIdBytes))
            {
                _logger.LogWarning("CorrelationId not found in request headers. Generating a new one for the reply.");
                correlationIdBytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            }
            var correlationId = Encoding.UTF8.GetString(correlationIdBytes);

            var responseJson = JsonSerializer.Serialize(responseEvent);
            var responseMessage = new Message<string, string>
            {
                Key = null, // Usually no key for replies
                Value = responseJson,
                Headers = new Headers
                {
                    { "correlationId", correlationIdBytes },
                    { "eventType", Encoding.UTF8.GetBytes(typeof(TResponseEvent).Name) }
                }
            };

            try
            {
                await _producer.ProduceAsync(_replyTopic, responseMessage);
                _logger.LogInformation("Sent response to topic {ReplyTopic} with correlationId {CorrelationId}.", _replyTopic, correlationId);
            }
            catch (ProduceException<string, string> ex)
            {
                _logger.LogError(ex, "Failed to send response to topic {ReplyTopic} with correlationId {CorrelationId}.", _replyTopic, correlationId);
            }
        }
    }
}