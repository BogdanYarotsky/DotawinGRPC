using DotawinGRPC.DataServer.DataAccess;
using DotawinGRPC.DataServer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddDbContext<DotawinDbContext>();
var app = builder.Build();
app.MapGrpcService<UpdaterService>();
app.Run();
