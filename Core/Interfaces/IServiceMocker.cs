
namespace MockSatelites.Core.Interfaces
{
    public interface IServiceMocker
    {
        void Initialize();
        void MockService(string serviceName);
    }
}
