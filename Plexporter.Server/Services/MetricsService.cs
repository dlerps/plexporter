using Plexporter.Plex.Client.Api;
using Plexporter.Plex.Client.Model;
using Plexporter.Plex.Client.Model.Enums;
using Prometheus;

namespace Plexporter.Server.Services;

public class MetricsService : IMetricsService
{
    private static readonly Gauge _activeSessiionsGauge = Metrics.CreateGauge(
        "plexporter_sessions_active",
        "Active sessions on Plex",
        "state"
    );

    private readonly IPlexApiClientFactory _plexApiClientFactory;

    private MediaContainer _currentSessions;

    public MetricsService(IPlexApiClientFactory factory)
    {
        _plexApiClientFactory = factory;
    }

    public async Task UpdateMetrics(CancellationToken cancellationToken)
    {
        var apiClient = _plexApiClientFactory.GetApiClient();
        cancellationToken.ThrowIfCancellationRequested();

        await Task.WhenAll(FetchSessions(apiClient, cancellationToken));

        UpdateSessionMetrics();
    }

    private async Task FetchSessions(IPlexApiClient apiClient, CancellationToken cancellationToken)
    {
        _currentSessions = await apiClient.GetSessions(cancellationToken);
    }

    private void UpdateSessionMetrics()
    {
        UpdateActiveSessionCount(PlayerState.Playing);
        UpdateActiveSessionCount(PlayerState.Paused);
        UpdateActiveSessionCount(PlayerState.Buffering);
    }

    private void UpdateActiveSessionCount(PlayerState playerState)
    {
        var count = _currentSessions
            .Videos
            .Count(vid => vid.Player != null && vid.Player.State == playerState);

        _activeSessiionsGauge
            .WithLabels(playerState.ToString())
            .Set(count);
    }
}