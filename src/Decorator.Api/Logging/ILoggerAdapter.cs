namespace Decorator.Api.Logging;

public interface ILoggerAdapter<T>
{
	void LogInformation(string message, params object?[] args);
	IDisposable TimedOperation(string message, params object?[] args);
}
