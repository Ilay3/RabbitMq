using EasyNetQ;
using RabbitMq.Application.Commands;

namespace EasyNetQDemo.Infrastructure.Messaging;

public class RabbitMqPublisher
{
    private readonly IBus _bus;

    public RabbitMqPublisher(IBus bus)
    {
        _bus = bus;
    }

    public async Task PublishAsync(CreateOrderCommand command)
    {
        await _bus.PubSub.PublishAsync(command);
        Console.WriteLine($"Сообщение опубликовано: Продукт - {command.Product}, Количество - {command.Quantity}");
    }
}
