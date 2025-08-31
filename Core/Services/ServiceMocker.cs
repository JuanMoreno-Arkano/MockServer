
using System.Text.Json;
using MockSatelites.Core.Interfaces;
using MockSatelites.Core.Models;
using MockSatelites.Core.WireMock;

namespace MockSatelites.Core.Services
{
    public class ServiceMocker : IServiceMocker
    {
        private readonly WireMockServerManager _serverManager = new();

        public void Initialize()
        {
            _serverManager.StartAllConfiguredServers();
        }

        public void MockService(string serviceName)
        {
            var config = LoadServiceConfig(serviceName);
            if (config == null)
            {
                Console.WriteLine($"Service '{serviceName}' not found.");
                return;
            }

            var request = LoadRequest(config);
            var response = LoadResponse(config);
            _serverManager.SetupMock(config, request, response);
        }

        private ServiceConfig LoadServiceConfig(string serviceName)
        {
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config", "services.json");
            if (!File.Exists(configPath)) return null;

            var json = File.ReadAllText(configPath);
            var configRoot = JsonSerializer.Deserialize<ServiceConfigRoot>(json);
            return configRoot?.Services?.FirstOrDefault(s => s.Name.Equals(serviceName, StringComparison.OrdinalIgnoreCase));
        }

        private string LoadRequest(ServiceConfig config)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Requests", "requests.json");
            if (!File.Exists(path)) return "";

            var json = File.ReadAllText(path);
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return dict != null && dict.ContainsKey(config.Name) ? JsonSerializer.Serialize(dict[config.Name]) : "";
        }

        private string LoadResponse(ServiceConfig config)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Responses", "responses.json");
            if (!File.Exists(path)) return "";

            var json = File.ReadAllText(path);
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return dict != null && dict.ContainsKey(config.Name) ? JsonSerializer.Serialize(dict[config.Name]) : "";
        }
    }
}
