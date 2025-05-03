using Google.Protobuf;
using Common.Messaging;

namespace Common.Infrastructure.Kafka.MessageNotifier
{
    /// <summary>
    /// Interface for a Kafka message notifier that handles messages of type <typeparamref name="TMessage"/>.
    /// </summary>
    /// <typeparam name="TMessage">The type of the Kafka message.</typeparam>
    public interface IKafkaMessageNotifier<TMessage> where TMessage : class, IMessage<TMessage>, new()
    {
        /// <summary>
        /// Subscribes to incoming Kafka messages with the specified handler.
        /// </summary>
        /// <param name="handler">The handler to be invoked when a Kafka message is received.</param>
        /// <returns>A subscription object that can be used to unsubscribe later.</returns>
        KafkaMessageSubscription Subscribe(Func<KafkaMessage<TMessage>, Task> handler);

        /// <summary>
        /// Unsubscribes from the Kafka message notifications.
        /// </summary>
        /// <param name="subscription">The subscription object obtained from the Subscribe method.</param>
        void Unsubscribe(KafkaMessageSubscription subscription);
    }
}