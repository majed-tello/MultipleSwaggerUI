using Microsoft.AspNetCore.Mvc;

namespace MultipleSwaggerUI.Demo;

[SwaggerGroup("Order")]
public class OrderController : ApiControllerBase
{
    private static readonly string[] _orders = new[]
       {
        "Order 1",
        "Order 2",
        "Order 3",
        "Order 4",
       };
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetOrders")]
    public IActionResult GetOrders()
    {
        return Ok(_orders);
    }
}
