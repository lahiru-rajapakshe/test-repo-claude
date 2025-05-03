using Google.Protobuf;
using Common.Messaging;

namespace Common.Infrastructure.Kafka.Producer
{
    public interface IKafkaProducer<TMessage> where TMessage : class, IMessage<TMessage>, new()
    {
        Task ProduceAsync(KafkaMessage<TMessage> kafkaMessage);
    }
}
