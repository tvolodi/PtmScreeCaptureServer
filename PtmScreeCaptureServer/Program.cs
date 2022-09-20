using MongoDB.Driver;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ScreenCapture"));

builder.Services.AddSingleton<MongoDbService>();

builder.Services.AddControllers();

builder.Services.AddHostedService<StartupService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
