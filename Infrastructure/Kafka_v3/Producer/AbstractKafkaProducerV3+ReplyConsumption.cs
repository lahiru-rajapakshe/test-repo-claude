using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Producer
{
    public abstract partial class AbstractKafkaProducerV3<TRequestEvent, TResponseEvent>
    {
        protected virtual void DefaultConsumeReplies(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult?.Message == null)
                        continue;

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
                _consumer?.Close();
                _consumer?.Dispose();
            }
        }
    }
}