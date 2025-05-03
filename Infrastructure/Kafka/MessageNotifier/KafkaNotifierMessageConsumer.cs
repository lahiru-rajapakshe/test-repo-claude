using System.Collections.Concurrent;
using Google.Protobuf;
using Common.Infrastructure.Kafka.Consumer;
using Common.Messaging;

namespace Common.Infrastructure.Kafka.MessageNotifier
{
    /// <summary>
    /// Kafka message consumer that also acts as a message notifier for messages of type <typeparamref name="TMessage"/>.
    /// </summary>
    /// <typeparam name="TMessage">The type of the Kafka message.</typeparam>
    public class KafkaNotifierMessageConsumer<TMessage> : IKafkaMessageNotifier<TMessage>, IKafkaMessageConsumer<TMessage>
        where TMessage : class, IMessage<TMessage>, new()
    {
        private readonly ConcurrentDictionary<KafkaMessageSubscription, Func<KafkaMessage<TMessage>, Task>> _handlers = new();

        /// <summary>
        /// Subscribes to incoming Kafka messages with the specified handler.
        /// </summary>
        /// <param name="handler">The handler to be invoked when a Kafka message is received.</param>
        /// <returns>A subscription object that can be used to unsubscribe later.</returns>
        public KafkaMessageSubscription Subscribe(Func<KafkaMessage<TMessage>, Task> handler)
        {
            var subscription = new KafkaMessageSubscription();
            _handlers.TryAdd(subscription, handler);
            return subscription;
        }

        /// <summary>
        /// Unsubscribes from the Kafka message notifications.
        /// </summary>
        /// <param name="subscription">The subscription object obtained from the Subscribe method.</param>
        public void Unsubscribe(KafkaMessageSubscription subscription)
        {
            if (subscription == null) throw new ArgumentNullException(nameof(subscription));

            _handlers.TryRemove(subscription, out _);
        }

        /// <summary>
        /// Consumes a Kafka message, invoking all subscribed handlers.
        /// </summary>
        /// <param name="kafkaMessage">The Kafka message to consume.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ConsumeAsync(KafkaMessage<TMessage> kafkaMessage)
        {
            foreach (var handler in _handlers.Values)
            {
                await handler(kafkaMessage);
            }
        }
    }
}
