using Google.Protobuf;
using Microsoft.Extensions.Options;
using Common.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Kafka.Producer
{
    /// <summary>
    /// Extension methods for registering Kafka producers.
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Registers a Kafka producer for the specified message type and topics.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="topics"></param>
        /// <typeparam name="TMessage"></typeparam>
        public static void AddKafkaProducer<TMessage>(
            this IServiceCollection services,
            IEnumerable<string> topics) where TMessage : class, IMessage<TMessage>, new() => services.AddTransient<IKafkaProducer<TMessage>>(
                sp =>
                new KafkaProducer<TMessage>(
                    topics,
                    sp.GetRequiredService<IOptions<KafkaConfig>>(),
                    sp,
                    sp.GetRequiredService<ILogger<KafkaProducer<TMessage>>>()));
    }
}
