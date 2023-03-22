namespace Plexporter.Server.Services;

public interface IMetricsService
{
    Task UpdateMetrics(CancellationToken cancellationToken);
}