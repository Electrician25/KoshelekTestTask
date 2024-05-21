using KoshelekWebServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddRouting();

builder.AddApplicationContext();

builder.Services.AddApplicationtServices();

var app = builder.Build();

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Run();