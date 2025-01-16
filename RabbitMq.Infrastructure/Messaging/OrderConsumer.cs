using EasyNetQ;
using RabbitMq.Application.Commands;

namespace EasyNetQDemo.Infrastructure.Messaging;

public class OrderConsumer
{
    private readonly IBus _bus;

    public OrderConsumer(IBus bus)
    {
        _bus = bus;
    }

    public void Start()
    {
        _bus.PubSub.Subscribe<CreateOrderCommand>("order_subscription", HandleOrder);
        Console.WriteLine("Подписчик запущен. Ожидание сообщений...");
    }

    private void HandleOrder(CreateOrderCommand command)
    {
        Console.WriteLine($"Получено сообщение: Продукт - {command.Product}, Количество - {command.Quantity}");
    }
}
