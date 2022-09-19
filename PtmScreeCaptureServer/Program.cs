using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ScreenCapture"));

builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
