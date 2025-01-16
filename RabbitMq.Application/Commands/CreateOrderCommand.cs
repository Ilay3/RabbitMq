namespace RabbitMq.Application.Commands;

public record CreateOrderCommand(string Product, int Quantity);
