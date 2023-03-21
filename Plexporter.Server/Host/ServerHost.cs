using Microsoft.Extensions.Hosting;
using Plexporter.Server.Configuration;
using Prometheus;

namespace Plexporter.Server.Host;

public class ServerHost : BackgroundService
{
    private readonly MetricsServerConfiguration _configuration;

    public ServerHost(MetricsServerConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        KestrelMetricServer? server = null;

        try
        {
            server = new KestrelMetricServer(_configuration.Port);
            server.Start();

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch (OperationCanceledException) { /* Expected for graceful shutdown */ }
        finally
        {
            server?.Dispose();
        }
    }
}