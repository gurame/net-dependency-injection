
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register all services in the Scanning.ConsoleApp.Services namespace
// LoggerAdapter is not registered because it is not in the Scanning.ConsoleApp.Services namespace
services.Scan(selector=> {
	selector.FromAssemblyOf<Program>()
		.AddClasses(f=> f.InNamespaces("Scanning.ConsoleApp.Services"))
			.AsImplementedInterfaces()
			.WithSingletonLifetime();
});

PrintRegisteredServices(services);

var serviceProvider = services.BuildServiceProvider();

static void PrintRegisteredServices(IServiceCollection services)
{
	foreach (var service in services)
	{
		Console.WriteLine($"Service: {service.ServiceType.Name} -> : {service.ImplementationType!.Name}, Lifetime: {service.Lifetime}");
	}
}