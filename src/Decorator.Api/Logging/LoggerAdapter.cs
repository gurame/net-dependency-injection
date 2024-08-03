

namespace Decorator.Api.Logging;

public class LoggerAdapter<T> : ILoggerAdapter<T>
{
	private readonly ILogger<T> _logger;
	public LoggerAdapter(ILogger<T> logger)
	{
		_logger = logger;
	}
    public void LogInformation(string message, params object?[] args)
    {
		_logger.LogInformation(message, args);
    }

    public IDisposable TimedOperation(string message, params object?[] args)
    {
        return new TimedLogOperation<T>(this, message, args);
    }
}
