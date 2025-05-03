namespace Common.Infrastructure.Kafka.MessageNotifier;

public class KafkaMessageSubscription
{
    private readonly Guid _id;

    internal KafkaMessageSubscription()
    {
        _id = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        return obj is KafkaMessageSubscription other && _id.Equals(other._id);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
}