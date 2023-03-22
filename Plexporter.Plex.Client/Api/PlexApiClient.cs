using Plexporter.Plex.Client.Configuration;
using Plexporter.Plex.Client.Model;

namespace Plexporter.Plex.Client.Api;

public class PlexApiClient : IPlexApiClient
{
    private readonly IPlexApi _plexApi;
    private readonly PlexConfiguration _plexConfiguration;

    public PlexApiClient(IPlexApi plexApi, PlexConfiguration plexConfiguration)
    {
        _plexApi = plexApi;
        _plexConfiguration = plexConfiguration;
    }

    public Task<MediaContainer> GetSessions() => _plexApi.GetSessions(_plexConfiguration.Token);
}