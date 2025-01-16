using EasyNetQ;
using RabbitMq.Application.Commands;

namespace RabbitMq.Infrastructure.Messaging;

public class RabbitMqPublisher
{
    private readonly IBus _bus;

    public RabbitMqPublisher(IBus bus)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    public async Task PublishAsync(PlaceOrderCommand command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command), "Command cannot be null.");
        }

        await _bus.PubSub.PublishAsync(command);
        Console.WriteLine($"Message published: CustomerEmail - {command.CustomerEmail}, Items - {command.Items.Count}");
    }
}
