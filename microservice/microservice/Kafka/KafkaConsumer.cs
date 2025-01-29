using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Text.Json;
using System.Text.RegularExpressions;

using System.Diagnostics;
using System.Text.Json;
using Confluent.Kafka;

namespace microservice.Kafka
{
    public class KafkaConsumer : IKafkaConsumer
    {

        //const string topic = "my-topic";
        //const string groupId = "test_group";
        //const string bootstrapServers = "localhost:9092";

        public IConsumer<Null, string> consumer;

        public KafkaConsumer() 
        {
            System.Diagnostics.Debug.WriteLine("KafkaConsumer ++++++++++++++++++++++");
        }

        public async Task ConsumeMessages(string topic)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:8888",
                GroupId = "test_group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Null, string>(config).Build();
            consumer.Subscribe(topic);

            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        var res = consumer.Consume();
                        System.Diagnostics.Debug.WriteLine("ConsumeConsumeConsumeConsumeConsumeConsume");
                        System.Diagnostics.Debug.WriteLine(res.Value);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"ДЕБИЛ!!!, ОШИБКА:{ex.Message}");
                    throw;
                }
                
            });

            
        }

        /*protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:8888",
                GroupId = "test_group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Null, string>(config).Build();
            consumer.Subscribe("Hi");

            while (true)
            {
                var res = consumer.Consume();
                System.Diagnostics.Debug.WriteLine(res);
            }
        }

        /*public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumerBuilder.Subscribe(topic);
                //var cancelToken = new CancellationTokenSource();

                Task.Run(() =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var consumer = consumerBuilder.Consume(cancellationToken);
                        if (consumer is null)
                        {
                            return;
                        }
                        Console.WriteLine($"!>!!!!!!!!!!!!! {consumer.Message.Value}");
                    };
                }, cancellationToken);
                return Task.CompletedTask;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }*/

    }
}
           

    
