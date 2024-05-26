using KoshelekWebServer.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddMvc();

builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddRouting();

builder.AddApplicationContext();

builder.Services.AddApplicationtServices();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.ConfigureLogging(logging =>
{
    logging.AddSerilog();
    logging.SetMinimumLevel(LogLevel.Information);
})
.UseSerilog();

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        Log.Logger.Error($"ORIGIN: {string.Join(",", context.Request.Headers["Origin"])}");

    }

    catch
    {
        Log.Logger.Error("#1");
    }

    try
    {
        Log.Logger.Error($"Request-Method: {string.Join(",", context.Request.Headers["Access-Control-Request-Method"])}");
    }

    catch
    {
        Log.Logger.Error("#2");
    }

    try
    {

        Log.Logger.Error($"Request-Headers: {string.Join(",", context.Request.Headers["Access-Control-Request-Headers"])}");
    }

    catch
    {
        Log.Logger.Error("#3");
    }
    await next();
});

app.UseCors(options =>
    options.WithOrigins("https://localhost:7248/")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Logger.LogInformation("Starting the server");

app.Run();