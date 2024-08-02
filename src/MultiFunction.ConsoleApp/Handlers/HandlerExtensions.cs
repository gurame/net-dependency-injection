using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MultiFunction.ConsoleApp.Handlers;

public static class HandlerExtensions
{
	public static IServiceCollection AddCommandHandlers(this IServiceCollection services, Assembly assembly)
	{
		services.AddScoped<HandlerManager>();

		var typeHandlers = GetTypeHandlers(assembly);
		foreach (var type in typeHandlers)
		{
			services.AddTransient(type);
		}

		return services;
	}

	public static IEnumerable<TypeInfo> GetTypeHandlers(Assembly assembly)
    {
        return assembly.DefinedTypes.Where(t => !t.IsInterface && !t.IsAbstract && typeof(IHandler).IsAssignableFrom(t));
    }
}
