namespace Decorator.Api.Services;

public class WeatherService : IWeatherService
{
    public string GetWeather()
    {
        return "The weather is sunny";
    }
}
