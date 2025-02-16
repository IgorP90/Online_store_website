using Confluent.Kafka;
using microservice;
using microservice.Kafka;
using microservice.Models;
using System.Threading;
using static Confluent.Kafka.ConfigPropertyNames;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

//Kafka--------------------------------------------------

builder.Services.AddSingleton<IKafkaConsumer, KafkaConsumer>();

//-------------------------------------------------------
string connection = builder.Configuration.GetConnectionString("MSSQLConfig");

builder.Services.AddScoped(x=> new Context(connection));
new Initializer(connection).InitializeDb();
//-----------------------
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
//-----------------

//WebApplicationBuilder builder = Host.CreateApplicationBuilder();
WebApplication app = builder.Build();
app.Services.GetService<IKafkaConsumer>().ConsumeMessages("Hi");

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
