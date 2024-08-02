using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Weather.WebApi.Filters;

public class DurationLoggerFilter : IAsyncActionFilter
{
	private readonly ILogger<DurationLoggerFilter> _logger;

    public DurationLoggerFilter(ILogger<DurationLoggerFilter> logger)
    {
        _logger = logger;
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var sw = Stopwatch.StartNew();
		try
		{
			return next();
		}
		finally
		{
			sw.Stop();
			// Resolving ILogger<T> from constructor injection
			_logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} took {sw.ElapsedMilliseconds}ms");
		}	
    }
}
