using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plexporter.Server.Configuration;
using Plexporter.Server.Host;

public static class Programm
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        var plexConfiguration = new PlexConfiguration();
        configuration.Bind("Plex", plexConfiguration);

        var metricsServerConfiguration = new MetricsServerConfiguration();
        configuration.Bind("MetricsServer", metricsServerConfiguration);

        await Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddLogging()
                    .AddSingleton(plexConfiguration)
                    .AddSingleton(metricsServerConfiguration)
                    .AddHostedService<ServerHost>();
            })
            .RunConsoleAsync();
    }
}