using Confluent.Kafka;
using microservice.Kafka;
using System.Threading;
using static Confluent.Kafka.ConfigPropertyNames;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

//Kafka--------------------------------------------------

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "my-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

/*using (IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
{
    consumer.Subscribe("my-topic");

    var cancelTocken = new CancellationTokenSource();


    while (cancelTocken!=null)
    {
        ConsumeResult<Ignore, string> consumeResult = consumer.Consume(cancelTocken.Token);

        app.MapGet("/", () => consumeResult.Value);
    }
};*/

//-----------------------------------------------------------

builder.Services.AddSingleton(new ConsumerBuilder<Ignore, string>(consumerConfig).Build());

Console.WriteLine($"AAAAAAAAAAAAAAAAAA");

app.MapGet("/", () => "Hello World!");

app.Run();
