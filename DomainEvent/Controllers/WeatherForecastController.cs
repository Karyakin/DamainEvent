using Microsoft.AspNetCore.Mvc;

namespace DomainEvent.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    
    private readonly IDispatchDomainEvents _dispatchDomainEvents;

    public WeatherForecastController(IDispatchDomainEvents dispatchDomainEvents)
    {
        _dispatchDomainEvents = dispatchDomainEvents;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var author = Author.Create("John Doe");
        await _dispatchDomainEvents.DispatchAsync(author);

        author.UpdateName("Jane Doe");
        await _dispatchDomainEvents.DispatchAsync(author);
        
        //Thread.Sleep(2000);
        return Ok();
    }
}