using Google.Protobuf;
using Microsoft.Extensions.Options;
using Common.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure.Kafka.Consumer
{
    public static class RegistrationExtensions
    {
        public static void AddKafkaConsumer<TMessage, TConsumer>(
            this IServiceCollection services, string topic, string consumerGroup, bool registeredConsumer = false)
            where TMessage : class, IMessage<TMessage>, new()
            where TConsumer : class, IKafkaMessageConsumer<TMessage>
        {
            if (registeredConsumer)
            {
                services.AddTransient<IKafkaMessageConsumer<TMessage>>(
                    sp => sp.GetRequiredService<TConsumer>());
            }
            else
            {
                services.AddScoped<IKafkaMessageConsumer<TMessage>, TConsumer>();
            }
            services.AddSingleton<IHostedService>(sp =>
                new KafkaConsumerHostedService<TMessage>(
                    topic,
                    consumerGroup,
                    sp.GetRequiredService<IOptions<KafkaConfig>>(),
                    sp.GetRequiredService<IServiceScopeFactory>(),
                    sp.GetRequiredService<ILogger<KafkaConsumerHostedService<TMessage>>>())
            );
        }
    }
}
