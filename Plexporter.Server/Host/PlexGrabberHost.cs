using Microsoft.Extensions.Hosting;
using Plexporter.Plex.Client.Api;

namespace Plexporter.Server.Host;

public class PlexGrabberHost : BackgroundService
{
    private readonly IPlexApi _plexApi;
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}