using Google.Protobuf;

namespace Common.Messaging;

public record KafkaMessage<TMessage>(TMessage Message, string? MessageKey = null, Dictionary<string, string>? Headers = null)
    where TMessage : class, IMessage<TMessage>, new(); 