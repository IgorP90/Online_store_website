using Confluent.Kafka;
using microservice;
using microservice.Kafka;
using System.Threading;
using static Confluent.Kafka.ConfigPropertyNames;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Kafka--------------------------------------------------

builder.Services.AddSingleton<IKafkaConsumer, KafkaConsumer>();
builder.Services.AddSingleton<TestDI>();

//-------------------------------------------------------

//WebApplicationBuilder builder = Host.CreateApplicationBuilder();
WebApplication app = builder.Build();
app.Services.GetService<IKafkaConsumer>().ConsumeMessages("Hi");

app.Run();
