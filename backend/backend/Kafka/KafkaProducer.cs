
using Confluent.Kafka;

namespace backend.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        public async Task SendMessageAsync(string topic, string message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:8888",
                AllowAutoCreateTopics = true,
                Acks = Acks.All
            };
            

            IProducer<Null,string> producer = new ProducerBuilder<Null,string>(config).Build();
            await producer.ProduceAsync(topic: "Hi", new Message<Null, string> { Value = message });
        }
    }
}
