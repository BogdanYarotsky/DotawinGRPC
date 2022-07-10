namespace DotawinGRPC.Updater.Services;

using Grpc.Net.ClientFactory;
using System.Threading.Tasks;

public class UpdaterService : IUpdaterClientService
{
    private readonly Updater.UpdaterClient client;

    public UpdaterService(GrpcClientFactory grpcClientFactory)
    {
        client = grpcClientFactory.CreateClient<Updater.UpdaterClient>("Updater");
    }

    public async Task<PatchInfo> GetPatchInfo()
    {
        return await client.GetLatestPatchAsync(new PatchRequest());
    }

    public Task<UpdateResult> SendDotaUpdate(DotaUpdate update) => throw new NotImplementedException();
    public async Task<string> SendMessage(string Message) =>
        (await client.SayHelloAsync(new HelloRequest { Name = Message })).Message;
}
