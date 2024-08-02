using Weather.ConsoleApp.Weather;

namespace Weather.ConsoleApp;

public class Application
{
	private readonly IWeatherService _weatherService;
	public Application(IWeatherService weatherService)
	{
		_weatherService = weatherService;
	}
	public async Task RunAsync(string location)
	{
		var weatherForecast = await _weatherService.GetWeatherForecastAsync(location);
		Console.WriteLine($"The weather in {location} is {weatherForecast.Summary}.");
	}
}
