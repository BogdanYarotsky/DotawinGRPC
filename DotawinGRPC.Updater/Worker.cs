namespace DotawinGRPC.Updater;

using DotawinGRPC.Updater.Services;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHost _host;
    private readonly IUpdaterClientService _updaterService;

    public Worker(ILogger<Worker> logger, IHost host, IUpdaterClientService updaterService)
    {
        _logger = logger;
        _host = host;
        _updaterService = updaterService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Kindly asking the server for patch information");
        var patchInfo = await _updaterService.GetPatchInfo();
        _logger.LogInformation("Current patch version is {version}, db was updated on {date}",
            patchInfo.Version, patchInfo.Date);
        await _host.StopAsync(stoppingToken);
    }
}
