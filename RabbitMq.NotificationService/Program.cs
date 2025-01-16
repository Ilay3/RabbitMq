using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EasyNetQ;
using RabbitMq.Application.Commands;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddEasyNetQ("host=localhost")
                .UseSystemTextJson(); 
    });

var host = builder.Build();

using var scope = host.Services.CreateScope();
var bus = scope.ServiceProvider.GetRequiredService<IBus>();

Console.WriteLine("Notification Service started...");

// Подписка на сообщения
bus.PubSub.Subscribe<PlaceOrderCommand>("notification_subscription", command =>
{
    Console.WriteLine($"Sending notification to {command.CustomerEmail}...");
});

Console.ReadLine();
