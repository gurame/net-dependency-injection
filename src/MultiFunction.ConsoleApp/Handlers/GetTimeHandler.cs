using MultiFunction.ConsoleApp.Console;
using MultiFunction.ConsoleApp.Time;

namespace MultiFunction.ConsoleApp.Handlers;

[CommandName("time")]
public class GetTimeHandler : IHandler
{
	private readonly IConsoleWriter _consoleWriter;
	private readonly IDateTimeProvider _dateTimeProvider;

    public GetTimeHandler(IConsoleWriter consoleWriter, IDateTimeProvider dateTimeProvider)
    {
        _consoleWriter = consoleWriter;
        _dateTimeProvider = dateTimeProvider;
    }

    public void Handle()
    {
        var timeNow = _dateTimeProvider.Now;
		_consoleWriter.Write($"The current time is {timeNow}");
    }
}
