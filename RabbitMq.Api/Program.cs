using EasyNetQ;
using RabbitMq.Infrastructure.Messaging;


var builder = WebApplication.CreateBuilder(args);

// ����������� EasyNetQ
builder.Services.AddEasyNetQ("host=localhost")
                .UseSystemTextJson();

// ����������� RabbitMqPublisher
builder.Services.AddSingleton<RabbitMqPublisher>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ������������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
