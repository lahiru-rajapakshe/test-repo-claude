using Google.Protobuf;
using Common.Infrastructure.Kafka.Consumer;
using Common.Infrastructure.Kafka.MessageNotifier;
using Common.Infrastructure.Kafka.Producer;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure.Kafka.RequestSender;

public static class RegistrationExtensions
{
    public static void AddKafkaRequestSender<TRequestMessage, TResponseMessage>(
        this IServiceCollection services,
        string requestTopic,
        string responseTopic)
    where TRequestMessage : class, IMessage<TRequestMessage>, new()
    where TResponseMessage : class, IMessage<TResponseMessage>, new()
    
    {
        var consumerGroup = $"responseTopic-awaiter-{Guid.NewGuid()}";
        
        services.AddSingleton<KafkaNotifierMessageConsumer<TResponseMessage>>();
        
        services.AddTransient<IKafkaMessageNotifier<TResponseMessage>>(
            sp => sp.GetRequiredService<KafkaNotifierMessageConsumer<TResponseMessage>>());
        
        services.AddKafkaConsumer<TResponseMessage, KafkaNotifierMessageConsumer<TResponseMessage>>(
            responseTopic, 
            consumerGroup,
            registeredConsumer: true);
        
        services.AddKafkaProducer<TRequestMessage>(new[] { requestTopic });

        services
            .AddTransient<
                IKafkaRequestSender<TRequestMessage, TResponseMessage>,
                KafkaRequestSender<TRequestMessage, TResponseMessage>>();
    }
}