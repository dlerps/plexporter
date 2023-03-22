using Microsoft.Extensions.Hosting;
using Plexporter.Plex.Client.Api;
using Plexporter.Server.Services;

namespace Plexporter.Server.Host;

public class PlexGrabberHost : BackgroundService
{
    private const int DELAY = 10000;

    private readonly IMetricsService _metricsService;

    public PlexGrabberHost(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (true)
            {
                await _metricsService.UpdateMetrics(stoppingToken);
                await Task.Delay(DELAY, stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            // shutting down gracefully
        }
    }
}