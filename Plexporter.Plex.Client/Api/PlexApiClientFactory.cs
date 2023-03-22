using Plexporter.Plex.Client.Configuration;
using Refit;

namespace Plexporter.Plex.Client.Api;

public class PlexApiClientFactory : IPlexApiClientFactory
{
    private readonly PlexConfiguration _configuration;

    private readonly RefitSettings _refitSettings;

    public PlexApiClientFactory(PlexConfiguration configuration)
    {
        _configuration = configuration;
        _refitSettings = new RefitSettings
        {
            ContentSerializer = new XmlContentSerializer()
        };
    }

    public IPlexApiClient GetApiClient() => new PlexApiClient(BuildApi(), _configuration);

    private IPlexApi BuildApi() => RestService.For<IPlexApi>(_configuration.ApiAddress, _refitSettings);
}