using RabbitMq.Application.Commands;
using RabbitMq.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMq.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly RabbitMqPublisher _publisher;

    public OrdersController(RabbitMqPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command)
    {
        if (command == null || string.IsNullOrWhiteSpace(command.CustomerEmail) || !command.Items.Any())
        {
            return BadRequest("Invalid order data.");
        }

        await _publisher.PublishAsync(command);
        return Ok("Order received and will be processed.");
    }
}
