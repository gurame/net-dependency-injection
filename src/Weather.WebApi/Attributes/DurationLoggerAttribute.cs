using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Weather.WebApi.Attributes;

public class DurationLoggerAttribute : Attribute, IAsyncActionFilter
{
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
			// Resolving ILogger<T> from the HttpContext.RequestServices, this is not a recommended way to resolve dependencies
			var serviceProvider = context.HttpContext.RequestServices;
			var logger = serviceProvider.GetRequiredService<ILogger<DurationLoggerAttribute>>();
			logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} took {sw.ElapsedMilliseconds}ms");
		}	
    }
}
