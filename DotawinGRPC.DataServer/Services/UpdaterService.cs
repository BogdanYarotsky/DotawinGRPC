namespace DotawinGRPC.DataServer.Services;
using DotawinGRPC.DataServer;
using Grpc.Core;

public class UpdaterService : Updater.UpdaterBase
{
    private readonly ILogger<UpdaterService> _logger;
    public UpdaterService(ILogger<UpdaterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = $"{request.Name}??? You are just a pussy!"
        });
    }

    public override Task<PatchInfo> GetLatestPatch(PatchRequest request, ServerCallContext context)
    {
        return Task.FromResult(new PatchInfo
        {
            Version = "7.31d",
            Date = DateTimeOffset.UtcNow.ToString()
        });
    }

    public override Task<UpdateResult> SaveDotaUpdateToDb(DotaUpdate request, ServerCallContext context)
    {
        _logger.LogWarning("Received {version} patch from the fellow client {peer}", request.Version, context.Peer);
        return Task.FromResult(new UpdateResult { Success = true, PatchInfo = new PatchInfo { } });
    }
}
