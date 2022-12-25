using Microsoft.AspNetCore.Mvc;

namespace MultipleSwaggerUI.Demo;

[SwaggerGroup("Customer")]
public class CustomerController : ApiControllerBase
{
    private static readonly string[] _customers = new[]
       {
        "Customer 1",
        "Customer 2",
        "Customer 3",
        "Customer 4",
       };
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetCustomers")]
    public IActionResult GetCustomers()
    {
        return Ok(_customers);
    }
}