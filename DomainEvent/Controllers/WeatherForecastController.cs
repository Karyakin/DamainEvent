using DomainEvent.EventsHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainEvent.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
       var rez = await _mediator.Send(new CreateAuthorCommand("Dima", "developer"));
        
        return Ok(rez);
    }
    
    [HttpGet("Change")]
    public async Task<IActionResult> Change()
    {
        var rez = await _mediator.Send(new ChangeAuthorCommand());
        
        return Ok(rez);
    }
}