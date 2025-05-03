using Google.Protobuf;

namespace Common.Infrastructure.Kafka.RequestSender
{
    /// <summary>
    /// Interface for sending requests to Kafka with a specified request message type and receiving responses
    /// with a specified response message type.
    /// </summary>
    /// <typeparam name="TRequestMessage">The type of the request message.</typeparam>
    /// <typeparam name="TResponseMessage">The type of the response message.</typeparam>
    public interface IKafkaRequestSender<TRequestMessage, TResponseMessage>
        where TRequestMessage : class, IMessage<TRequestMessage>, new()
        where TResponseMessage : class, IMessage<TResponseMessage>, new()
    {
        /// <summary>
        /// Sends a request message to Kafka and asynchronously waits for a response.
        /// </summary>
        /// <param name="message">The request message to be sent.</param>
        /// <param name="messageKey">The key associated with the message for routing purposes.</param>
        /// <returns>A task representing the asynchronous operation and containing the response message.</returns>
        Task<TResponseMessage> SendAsync(TRequestMessage message, string messageKey);
    }
}