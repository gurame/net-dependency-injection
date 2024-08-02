using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MultiFunction.ConsoleApp;
using MultiFunction.ConsoleApp.Console;
using MultiFunction.ConsoleApp.Handlers;
using MultiFunction.ConsoleApp.Time;
using MultiFunction.ConsoleApp.Weather;


var services = new ServiceCollection();

services.AddScoped<IConsoleWriter, ConsoleWriter>();
services.AddScoped<IDateTimeProvider, DateTimeProvider>();
services.AddScoped<IWeatherService, WeatherService>();
services.AddCommandHandlers(Assembly.GetExecutingAssembly());

services.AddScoped<Application>();

var serviceProvider = services.BuildServiceProvider();

var application = serviceProvider.GetRequiredService<Application>();
if (args.Length == 0)
{
	args = ["time"];
}

application.Run(args);