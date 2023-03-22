namespace Plexporter.Plex.Client.Api;

public interface IPlexApiClientFactory
{
    IPlexApiClient GetApiClient();
}