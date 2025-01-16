using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EasyNetQ;
using RabbitMq.Application.Commands;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Регистрация EasyNetQ с использованием System.Text.Json
        services.AddEasyNetQ("host=localhost")
                .UseSystemTextJson(); // Подключаем System.Text.Json
    });

var host = builder.Build();

using var scope = host.Services.CreateScope();
var bus = scope.ServiceProvider.GetRequiredService<IBus>();

Console.WriteLine("Inventory Service started...");

// Подписка на сообщения
bus.PubSub.Subscribe<PlaceOrderCommand>("inventory_subscription", command =>
{
    foreach (var item in command.Items)
    {
        Console.WriteLine($"Updating inventory for product: {item.ProductName}, Quantity: {item.Quantity}");
    }
});

Console.ReadLine();
