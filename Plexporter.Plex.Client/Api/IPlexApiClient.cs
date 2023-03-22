using Plexporter.Plex.Client.Model;

namespace Plexporter.Plex.Client.Api;

public interface IPlexApiClient
{
    Task<MediaContainer> GetSessions(CancellationToken cancellationToken = default);
}