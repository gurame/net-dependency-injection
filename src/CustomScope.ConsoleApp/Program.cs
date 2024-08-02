using CustomScope.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

services.AddScoped<ExampleService>();

var serviceProvider = services.BuildServiceProvider();

/*
Use IServiceScopeFactory instead of directly creating it from ServiceProvider

Key Differences

Access to Service Provider:
	Direct from Service Provider: Requires direct access to the IServiceProvider.
	Using IServiceScopeFactory: Only requires access to the IServiceScopeFactory, which can be injected into classes.

Separation of Concerns:
	Direct from Service Provider: Can lead to tight coupling with the service provider.
	Using IServiceScopeFactory: Promotes better decoupling and abstraction.

Flexibility:
	Direct from Service Provider: Simple and direct for scenarios where the service provider is readily available.
	Using IServiceScopeFactory: More flexible for use cases where the service provider is not directly available or for testing purposes.

Dependency Injection:
	Direct from Service Provider: Less flexible in terms of dependency injection and testing.
	Using IServiceScopeFactory: Easier to mock and inject, making it more suitable for unit testing and better adherence to dependency injection principles.
*/

var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
using (var scope = serviceScopeFactory.CreateScope())
{
	var service = scope.ServiceProvider.GetRequiredService<ExampleService>();
	Console.WriteLine(service.Id);
}
using (var scope = serviceScopeFactory.CreateScope())
{
	var service = scope.ServiceProvider.GetRequiredService<ExampleService>();
	Console.WriteLine(service.Id);
}