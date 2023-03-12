using Messaging.Publisher.Commands;
using Messaging.Shared.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Messaging.Publisher.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IDispatcher _dispatcher;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(IDispatcher dispatcher, ILogger<CustomerController> logger)
    {
        _dispatcher = dispatcher;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomer command)
    {
        await _dispatcher.SendAsync(command with {Id = Guid.NewGuid()});
        return NoContent();
    }
}