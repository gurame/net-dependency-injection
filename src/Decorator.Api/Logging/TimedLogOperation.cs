using System.Diagnostics;

namespace Decorator.Api.Logging;

public class TimedLogOperation<T> : IDisposable
{
	private readonly ILoggerAdapter<T> _logger;
	private readonly string _message;
	private readonly object?[] _args;
	private readonly Stopwatch _stopwatch;

    public TimedLogOperation(ILoggerAdapter<T> logger, string message, object?[] args)
    {
        _logger = logger;
        _message = message;
        _args = args;
		_stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _stopwatch.Stop();
		_logger.LogInformation($"{_message} in {_stopwatch.ElapsedMilliseconds}ms", _args);
    }
}
