
namespace Weather.WebApi;

public class BackgroundTicker : BackgroundService
{
	private readonly ILogger<BackgroundTicker> _logger;
    public BackgroundTicker(ILogger<BackgroundTicker> logger)
    {
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
		{
			_logger.LogInformation("Timed Hosted Service is working.");
			await Task.Delay(2000, stoppingToken);
		}
    }
}
