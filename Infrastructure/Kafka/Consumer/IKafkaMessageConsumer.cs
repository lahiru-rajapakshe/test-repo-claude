using Google.Protobuf;
using Common.Messaging;

namespace Common.Infrastructure.Kafka.Consumer
{
    /// <summary>
    /// Represents a Kafka message consumer for messages of type <typeparamref name="TMessage"/>.
    /// </summary>
    /// <typeparam name="TMessage">The type of the Kafka message.</typeparam>
    public interface IKafkaMessageConsumer<TMessage> where TMessage : class, IMessage<TMessage>, new()
    {
        /// <summary>
        /// Asynchronously handles the consumption of a Kafka message.
        /// </summary>
        /// <param name="kafkaMessage">The Kafka message to be consumed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ConsumeAsync(KafkaMessage<TMessage> kafkaMessage);
    }
}