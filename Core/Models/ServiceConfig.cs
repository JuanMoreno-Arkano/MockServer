
namespace MockSatelites.Core.Models
{
    public class ServiceConfig
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Operation { get; set; }
    }

    public class ServiceConfigRoot
    {
        public List<ServiceConfig> Services { get; set; } = new();
    }
}
