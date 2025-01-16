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

Console.WriteLine("Inventory Service started...");

bus.PubSub.Subscribe<PlaceOrderCommand>("inventory_subscription", command =>
{
    foreach (var item in command.Items)
    {
        Console.WriteLine($"Updating inventory for product: {item.ProductName}, Quantity: {item.Quantity}");
    }
});

Console.ReadLine();
