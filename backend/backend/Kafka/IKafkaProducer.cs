namespace backend.Kafka
{
    public interface IKafkaProducer
    {
        Task SendMessageAsync(string topic, string message);
    }
}
