
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MockSatelites.Core.Interfaces;
using MockSatelites.Core.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IServiceMocker, ServiceMocker>();
    })
    .Build();

var serviceMocker = host.Services.GetRequiredService<IServiceMocker>();
serviceMocker.Initialize();

Console.WriteLine("Ingrese el nombre del servicio a mockear:");
var serviceName = Console.ReadLine();
serviceMocker.MockService(serviceName);
Console.WriteLine("Servicio listo para mockear");
Console.ReadLine();
