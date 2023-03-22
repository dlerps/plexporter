using Plexporter.Plex.Client.Model;
using Refit;

namespace Plexporter.Plex.Client.Api;

public interface IPlexApi
{
    [Get("/status/sessions")]
    Task<MediaContainer> GetSessions(
        [AliasAs("X-Plex-Token")] string plexToken,
        CancellationToken cancellationToken = default
    );
}