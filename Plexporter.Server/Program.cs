using Plexporter.Plex.Client.Api;
using Prometheus;
using Refit;

var plexApiClient = RestService.For<IPlexApi>(
    "",
    new RefitSettings 
    {
        ContentSerializer = new XmlContentSerializer()
    }
);

var sessions = await plexApiClient.GetSessions("");

using var server = new KestrelMetricServer(port: 31337);
server.Start();

Console.WriteLine("Open http://localhost:31337/metrics in a web browser.");
Console.WriteLine("Press enter to exit.");
Console.ReadLine();
