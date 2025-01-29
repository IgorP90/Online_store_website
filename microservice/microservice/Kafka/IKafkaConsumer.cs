namespace microservice.Kafka
{
    public interface IKafkaConsumer
    {
        Task ConsumeMessages(string topic);
    }
}
