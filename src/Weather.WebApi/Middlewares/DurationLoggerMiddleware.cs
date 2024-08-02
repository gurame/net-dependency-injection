using System.Diagnostics;

namespace Weather.WebApi.Middlewares;

public class DurationLoggerMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<DurationLoggerMiddleware> _logger;
    public DurationLoggerMiddleware(RequestDelegate next, ILogger<DurationLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

	public async Task Invoke(HttpContext context)
	{
		var sw = Stopwatch.StartNew();
		try
		{
			await _next(context);
		}
		finally
		{
			sw.Stop();
			_logger.LogInformation($"Request {context.Request.Path} took {sw.ElapsedMilliseconds}ms");
		}
	}
}
