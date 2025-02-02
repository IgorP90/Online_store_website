
using Confluent.Kafka;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace backend.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly ProducerConfig producerConfig;
        public KafkaProducer(ProducerConfig producerConfig) => this.producerConfig = producerConfig;

        public async Task SendMessageAsync(string topic, string message)
        {

            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = "localhost:8888",
                AllowAutoCreateTopics = true,
                Acks = Acks.All
            };

            try
            {
                Debug.WriteLine("Kafka OK");
                IProducer<Null,string> producer = new ProducerBuilder<Null,string>(config).Build();
                await producer.ProduceAsync(topic: "Hi", new Message<Null, string> { Value = message });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Kafka ERROR: {ex}");
            }
             
        }
    }
}
