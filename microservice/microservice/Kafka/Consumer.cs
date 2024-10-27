using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Text.Json;
using System.Text.RegularExpressions;

using System.Diagnostics;
using System.Text.Json;
using Confluent.Kafka;

namespace microservice.Kafka
{
    public class Consumer : IHostedService
    {

        const string topic = "my-topic";
        const string groupId = "test_group";
        const string bootstrapServers = "localhost:9092";

        public Task StartAsync(CancellationToken cancellationToken)
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
        }
    }
}
           

    
