
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Settings;
using MockSatelites.Core.Models;
using System.Text.Json;

namespace MockSatelites.Core.WireMock
{
    public class WireMockServerManager
    {
        private readonly Dictionary<string, WireMockServer> _servers = new();

        public void StartAllConfiguredServers()
        {
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config", "services.json");
            if (!File.Exists(configPath)) return;

            var json = File.ReadAllText(configPath);
            var configRoot = JsonSerializer.Deserialize<ServiceConfigRoot>(json);
            if (configRoot?.Services == null) return;

            foreach (var service in configRoot.Services)
            {
                var uri = new Uri(service.Url);
                var port = uri.Port;
                if (_servers.ContainsKey(service.Url)) continue;

                var server = WireMockServer.Start(new WireMockServerSettings
                {
                    Port = port,
                    StartAdminInterface = true,
                    ReadStaticMappings = false
                });

                _servers[service.Url] = server;
                Console.WriteLine($"Mock iniciado en {service.Url}");
            }
        }

        public void SetupMock(ServiceConfig config, string request, string response)
        {
            if (!_servers.ContainsKey(config.Url)) return;

            var uri = new Uri(config.Url);
            var path = uri.AbsolutePath;

            var method = config.Type == "REST" ? config.Operation?.ToUpperInvariant() ?? "GET" : "POST";

            _servers[config.Url]
                .Given(Request.Create().WithPath(path).UsingMethod(method))
                .RespondWith(Response.Create().WithBody(response).WithStatusCode(200));
        }
    }
}
