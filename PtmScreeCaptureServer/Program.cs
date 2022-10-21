using MongoDB.Driver;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;
using SharpCompress.Common;
using System.Text;

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

//app.Use(async (context, next) =>
//{
//    context.Request.EnableBuffering();

//    var request = context.Request;

//    var sb = new StringBuilder();

//    var line1 = $"{request.Method} {request.Scheme}://{request.Host}{request.Path} {request.Protocol}";
//    sb.AppendLine(line1);

//    foreach (var (key, value) in request.Headers)
//    {
//        var header = $"{key}: {value}";
//        sb.AppendLine(header);
//    }
//    sb.AppendLine();

//    using var reader = new StreamReader(request.Body);
//    var body = await reader.ReadToEndAsync();
//    if (!string.IsNullOrWhiteSpace(body))
//        sb.AppendLine(body);
//    File.WriteAllText(Guid.NewGuid().ToString(), sb.ToString());

//    Console.WriteLine(request.Body.ToString());

//    await next.Invoke();
//});

app.Run();


