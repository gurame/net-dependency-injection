using Decorator.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<WeatherService>();
builder.Services.AddTransient<IWeatherService>(provider=>
{
	var weatherService = provider.GetRequiredService<WeatherService>();
	var logger = provider.GetRequiredService<ILogger<IWeatherService>>();
	return new LoggerWeatherService(weatherService, logger);
});

var app = builder.Build();

app.MapGet("/", (IWeatherService weatherService) => weatherService.GetWeather());

app.Run();
