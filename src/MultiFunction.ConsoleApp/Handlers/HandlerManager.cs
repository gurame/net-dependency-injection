using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MultiFunction.ConsoleApp.Handlers;

public class HandlerManager
{
	private readonly Dictionary<string, Type> _handlerTypes = [];
	private readonly IServiceScopeFactory _serviceScopeFactory;

    public HandlerManager(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
		RegisterCommandHandlers();
    }

	private void RegisterCommandHandlers()
    {
		var typeHanlders = HandlerExtensions.GetTypeHandlers(Assembly.GetExecutingAssembly());

        foreach (var type in typeHanlders)
        {
            var commandName = type.GetCustomAttribute<CommandNameAttribute>();
            if (commandName is null)
            {
                continue;
            }
            _handlerTypes[commandName.Name] = type;
        }
    }

    public IHandler? GetHandlerForCommandName(string command)
	{
		var handlerType = _handlerTypes.GetValueOrDefault(command);
		if (handlerType is null)
		{
			return null;
		}
		using var scope = _serviceScopeFactory.CreateScope();
		return (IHandler)scope.ServiceProvider.GetRequiredService(handlerType);
	}
}
