using MultiFunction.ConsoleApp.Console;
using MultiFunction.ConsoleApp.Weather;

namespace MultiFunction.ConsoleApp.Handlers;

[CommandName("weather")]
public class GetWeatherHandler : IHandler
{
	private readonly IConsoleWriter _consoleWriter;
	private readonly IWeatherService _weatherService;

	public GetWeatherHandler(IConsoleWriter consoleWriter, IWeatherService weatherService)
	{
		_consoleWriter = consoleWriter;
		_weatherService = weatherService;
	}

	public void Handle()
	{
		var weather = _weatherService.GetWeather();
		_consoleWriter.Write($"The current weather is {weather}");
	}
}
