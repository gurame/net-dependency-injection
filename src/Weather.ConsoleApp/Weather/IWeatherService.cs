namespace Weather.ConsoleApp.Weather;

public interface IWeatherService
{
	Task<WeatherForecast> GetWeatherForecastAsync(string location);
}
