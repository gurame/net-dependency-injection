
namespace Weather.ConsoleApp.Weather;

public class OpenWeatherService : IWeatherService
{
    public Task<WeatherForecast> GetWeatherForecastAsync(string location)
    {
        return Task.FromResult(new WeatherForecast { Summary = "Sunny" });
    }
}
