using System.Diagnostics;
using Decorator.Api.Logging;

namespace Decorator.Api.Services;

public class LoggerWeatherService : IWeatherService
{
	private readonly IWeatherService _weatherService;
	private readonly ILoggerAdapter<IWeatherService> _logger;
    public LoggerWeatherService(IWeatherService weatherService, ILoggerAdapter<IWeatherService> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public string GetWeather()
    {
        using var timed = _logger.TimedOperation("GetWeather");
		var result = _weatherService.GetWeather();
		return result;
    }
}
