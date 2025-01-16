using RabbitMq.Domain.Entities;

namespace RabbitMq.Application.Commands;

public record PlaceOrderCommand(string CustomerEmail, List<OrderItem> Items);