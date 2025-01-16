using EasyNetQ;
using RabbitMq.Infrastructure.Messaging;


var builder = WebApplication.CreateBuilder(args);

// Регистрация EasyNetQ
builder.Services.AddEasyNetQ("host=localhost")
                .UseSystemTextJson();

// Регистрация RabbitMqPublisher
builder.Services.AddSingleton<RabbitMqPublisher>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурация
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
