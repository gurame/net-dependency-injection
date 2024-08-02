using System.Diagnostics;

namespace Decorator.Api.Services;

public class LoggerWeatherService : IWeatherService
{
	private readonly IWeatherService _weatherService;
	private readonly ILogger<IWeatherService> _logger;
    public LoggerWeatherService(IWeatherService weatherService, ILogger<IWeatherService> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public string GetWeather()
    {
        var sw = Stopwatch.StartNew();
		var result = _weatherService.GetWeather();
		sw.Stop();
		_logger.LogInformation($"GetWeather took {sw.ElapsedMilliseconds}ms");
		return result;
    }
}
