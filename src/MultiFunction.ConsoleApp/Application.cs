using MultiFunction.ConsoleApp.Console;
using MultiFunction.ConsoleApp.Handlers;

namespace MultiFunction.ConsoleApp;

public class Application
{
	private readonly IConsoleWriter _consoleWriter;
	private readonly HandlerManager _handlerManager;
    public Application(IConsoleWriter consoleWriter, 
		HandlerManager handlerManager)
    {
		_consoleWriter = consoleWriter;
        _handlerManager = handlerManager;
    }

    public void Run(string[] args)
	{
		var command = args[0];
		var handler = _handlerManager.GetHandlerForCommandName(command);
		if (handler is null)
		{
			_consoleWriter.Write($"Command '{command}' not found");
			return;
		}

		handler.Handle();
	}
}
