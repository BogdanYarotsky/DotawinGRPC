using DotawinGRPC.Updater;
using DotawinGRPC.Updater.Services;
using static System.Environment;

bool isDev = GetEnvironmentVariable("DOTNET_ENVIRONMENT") == "Development";
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddGrpcClient<Updater.UpdaterClient>("Updater", o =>
        {
            o.Address = new Uri("https://host.docker.internal:49153");
        })
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            var handler = new HttpClientHandler();
            if (isDev)
            {
                handler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            }
            return handler;
        });
        services.AddSingleton<IUpdaterClientService, UpdaterService>();
    })
    .Build();

await host.RunAsync();
