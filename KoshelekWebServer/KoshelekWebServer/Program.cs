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