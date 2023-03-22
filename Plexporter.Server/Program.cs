using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Plexporter.Server;

public static class Programm
{
    public static async Task Main(string[] args)
    {
        await Host
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            {
                builder
                    .AddJsonFile("appsettings.json", false)
                    .AddEnvironmentVariables()
                    .AddCommandLine(args);
            })
            .ConfigureServices(Bootstrap.ConfigureServices)
            .RunConsoleAsync();
    }
}