var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("ScreenCapture"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
