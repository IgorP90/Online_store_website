using Confluent.Kafka;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "host1:9092,host2:9092",
    GroupId = "foo",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

app.MapGet("/", () => "Hello World!");

app.Run();
