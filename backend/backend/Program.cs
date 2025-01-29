using backend.CRUD;
using backend.Kafka;
using backend.Models;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3333").AllowAnyMethod().AllowAnyHeader();
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

string connection = builder.Configuration.GetConnectionString("MSSQLConfig");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Kafka-----------------
//string config = builder.Configuration.GetConnectionString("KafkaConfig");
//builder.Services.AddScoped<new ProducerBuilder<Null, string>(config)>();


/*ProducerConfig producerConfig = new ProducerConfig
{
    BootstrapServers = builder.Configuration.GetConnectionString("KafkaConfig")
};*/

/*using (IProducer<Null, string> producer = new ProducerBuilder<Null, string>(producerConfig).Build()) 
{
    producer.Produce("my-topic", new Message<Null, string> { Value = "a log message" });
}*/
//builder.Services.AddScoped<IProducer<string, string>, Producer<string, string>;

//Redis-------------------
builder.Services.AddStackExchangeRedisCache(options => {
    string connection = builder.Configuration.GetConnectionString("RedisConfig");
    options.Configuration = connection;
});

//-----------------------------
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
