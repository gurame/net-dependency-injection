using Decorator.Api.Logging;
using Decorator.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
builder.Services.AddTransient<WeatherService>();

builder.Services.AddTransient<IWeatherService, WeatherService>();
/*
// Registering the LoggerWeatherService as a decorator
builder.Services.AddTransient<IWeatherService>(provider=>
{
	var weatherService = provider.GetRequiredService<WeatherService>();
	var logger = provider.GetRequiredService<ILogger<IWeatherService>>();
	return new LoggerWeatherService(weatherService, logger);
});
*/
// Decorate the WeatherService with the LoggerWeatherService using Scrutor
builder.Services.Decorate<IWeatherService, LoggerWeatherService>();

var app = builder.Build();

app.MapGet("/", (IWeatherService weatherService) => weatherService.GetWeather());

app.Run();
