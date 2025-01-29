using Confluent.Kafka;

using microservice.Models;

namespace microservice.Microservice
{
    public class ConsumerService
    { 
        /*private IConsumer<string, string> consumer;
        public ConsumerService(IConsumer<string, string> consumer) => this.consumer = consumer;

       
        public Task StartAsync(CancellationToken cancellationToken)
        {
            consumer.Subscribe("order-events");
            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    ConsumeResult<string, string>? consumeResult = consumer.Consume(cancellationToken);
                    var orderDetails = consumeResult.Message.Value;
                    Console.WriteLine(orderDetails);
                }
            }, cancellationToken);
            return Task.CompletedTask;
        }*/
    }
}
