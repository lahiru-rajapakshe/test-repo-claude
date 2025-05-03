using Common.Infrastructure.Localization;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Infrastructure.Kafka_v3.Consumer;

public abstract partial class AbstractKafkaConsumerV3<TRequestEvent, TResponseEvent>
{
    private async Task ConsumeLoop(CancellationToken cancellationToken)
    {
        List<Task> processingTasks = new(); // Track active tasks

        try
        {
            while (!cancellationToken.IsCancellationRequested)
                try
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult?.Message == null)
                        continue;

                    var message = consumeResult.Message;
                    var headers = message.Headers;

                    var processingTask = Task.Run(async () =>
                    {
                        var language = ExtractLanguageHeader(headers);
                        SetCurrentCulture(language);
                        KafkaLocalizationContext.SetLanguage(language);

                        try
                        {
                            var requestEvent = DeserializeMessage(message.Value);
                            if (requestEvent == null)
                                return;

                            _logger.LogInformation(
                                "Received message on topic {Topic}, partition {Partition}, offset {Offset}: {Message}",
                                _requestTopic, consumeResult.Partition.Value, consumeResult.Offset.Value,
                                message.Value);

                            var responseEvent = await HandleMessageAsync(requestEvent);

                            if (!string.IsNullOrEmpty(_replyTopic) && !(responseEvent is VoidResponse) &&
                                _producer != null) await SendReplyAsync(responseEvent, headers);

                            // Commit after processing
                            try
                            {
                                _consumer.Commit(consumeResult);
                                _logger.LogDebug(
                                    "Committed offset {Offset} for partition {Partition} on topic {Topic}.",
                                    consumeResult.Offset.Value, consumeResult.Partition.Value, _requestTopic);
                            }
                            catch (KafkaException ex)
                            {
                                _logger.LogError(ex,
                                    "Error during commit for offset {Offset}, partition {Partition} on topic {Topic}.",
                                    consumeResult.Offset.Value, consumeResult.Partition.Value, _requestTopic);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error while processing message from topic {Topic}.", _requestTopic);
                        }
                        finally
                        {
                            RestoreCulture();
                        }
                    }, cancellationToken);

                    processingTasks.Add(processingTask);

                    // Optional: clean up finished tasks to avoid memory leak
                    processingTasks.RemoveAll(t => t.IsCompleted);
                }
                catch (ConsumeException ex)
                {
                    _logger.LogError(ex, "Consume error on topic {Topic}.", _requestTopic);
                }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Consumer loop for topic {Topic} is stopping due to cancellation.", _requestTopic);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error in consumer loop for topic {Topic}.", _requestTopic);
        }
        finally
        {
            try
            {
                _logger.LogInformation("Waiting for all message processing tasks to complete...");
                await Task.WhenAll(processingTasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while waiting for processing tasks to finish.");
            }

            Cleanup();
        }
    }
}