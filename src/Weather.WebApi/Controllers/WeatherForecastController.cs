using Microsoft.AspNetCore.Mvc;
using Weather.WebApi.Attributes;

namespace Weather.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Resolve dependency from method parameter
    [HttpGet(Name = "GetWeatherForecast")]
    [DurationLogger]
    public IEnumerable<WeatherForecast> Get([FromServices]ILogger<WeatherForecastController> logger)
    {
        logger.LogInformation("Getting weather forecast");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
