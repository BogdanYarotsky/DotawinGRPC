namespace DotawinGRPC.Updater.Services;

public interface IUpdaterClientService
{
    public Task<string> SendMessage(string Message);
    public Task<UpdateResult> SendDotaUpdate(DotaUpdate update);
    public Task<PatchInfo> GetPatchInfo();
}