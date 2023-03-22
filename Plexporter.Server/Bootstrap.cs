using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plexporter.Plex.Client.Api;
using Plexporter.Plex.Client.Configuration;
using Plexporter.Server.Configuration;
using Plexporter.Server.Host;
using Plexporter.Server.Services;
using Prometheus;

namespace Plexporter.Server;

public static class Bootstrap
{
    public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        var plexConfiguration = new PlexConfiguration();
        context.Configuration.Bind("Plex", plexConfiguration);

        var metricsServerConfiguration = new MetricsServerConfiguration();
        context.Configuration.Bind("MetricsServer", metricsServerConfiguration);

        services.AddLogging()
            .AddSingleton(plexConfiguration)
            .AddSingleton(metricsServerConfiguration)
            .AddSingleton<IPlexApiClientFactory, PlexApiClientFactory>()
            .AddScoped<IMetricsService, MetricsService>()
            .AddHostedService<PlexGrabberHost>()
            .AddHostedService<ServerHost>();
    }
}